using FdkElevator.AppDbContext;
using FdkElevator.DTOS.PDFDTO;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Surveyors;
using FdkElevator.Services.IServices;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace FdkElevator.Services
{
    public class PdfService : IPdf
    {
        //private static readonly string HeaderBlue = "#1E73BE";
        //private static readonly string LightBlue = "#D6E8F7";
        //private static readonly string RowGray = "#F5F5F5";
        //private static readonly string DarkBlue = "#0D4F8C";

     
        private readonly string _logoPath;    
        private readonly string _logoBase64= "https://img.magnific.com/premium-vector/eqh-logo-design-initial-letter-eqh-monogram-logo-using-hexagon-shape_1101554-16445.jpg?semt=ais_hybrid&w=740&q=80";
        private readonly ApplicationDbContext _context;

        public PdfService(ApplicationDbContext context)
        {
            _context = context;
        }


        private const string HeaderBlue = "#1E73BE";
        private const string LightBlue = "#D6E8F7";
        private const string RowGray = "#F5F5F5";
        private const string Green = "#2E7D32";
        private const string Red = "#C62828";


        public byte[] GeneratePdf(QuotationRequest q, TenantInformation tenant)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.MarginHorizontal(25);
                    page.MarginTop(15);
                    page.MarginBottom(15);
                    page.DefaultTextStyle(x => x.FontSize(8).FontFamily("Arial"));

                    page.Header().Element(c => ComposeHeader(c, q, tenant));
                    page.Content().PaddingTop(8).Element(c => ComposeContent(c, q, tenant));
                    page.Footer().Element(c => ComposeFooter(c, tenant));
                });
            })
            .GeneratePdf();
        }

        // ─── HEADER ────────────────────────────────────────────────────────────────────
        private void ComposeHeader(IContainer container, QuotationRequest q, TenantInformation tenant)
        {
            container.Column(col =>
            {
                col.Spacing(4);

                // Brand bar
                col.Item().Background(HeaderBlue).Padding(8).Row(row =>
                {
                    if (!string.IsNullOrWhiteSpace(tenant.Logo_URL))
                    {
                        var logoBytes = FetchImageBytes(tenant.Logo_URL);
                        if (logoBytes.Length > 0)
                        {
                            row.ConstantItem(45).MaxHeight(35).Image(logoBytes, ImageScaling.FitArea);
                            row.ConstantItem(6);
                        }
                    }

                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text(tenant.Name ?? string.Empty)
                            .FontSize(14).Bold().FontColor(Colors.White);
                        if (!string.IsNullOrWhiteSpace(tenant.Address))
                            c.Item().Text(tenant.Address)
                                .FontSize(7).FontColor(Colors.White);
                    });

                    row.ConstantItem(140).Column(c =>
                    {
                        if (!string.IsNullOrWhiteSpace(tenant.PhoneNumber))
                            c.Item().AlignRight().Text(tenant.PhoneNumber)
                                .FontSize(7).FontColor(Colors.White);
                        if (!string.IsNullOrWhiteSpace(tenant.Email))
                            c.Item().AlignRight().Text(tenant.Email)
                                .FontSize(7).FontColor(Colors.White).Italic();
                    });
                });

                // Meta table
                col.Item().Border(1).BorderColor(HeaderBlue).Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.RelativeColumn(2);
                        cols.RelativeColumn(4);
                        cols.RelativeColumn(2);
                        cols.RelativeColumn(3);
                    });

                    MetaLabelCell(table, "QUOTATION REF#");
                    MetaValueCell(table, q.QuotationNumber ?? string.Empty);
                    MetaLabelCell(table, "QUOTATION DATE");
                    MetaValueCell(table, q.QuotationDate ?? string.Empty);

                    MetaLabelCell(table, "CLIENT");
                    MetaValueCell(table, q.ClientName ?? string.Empty);
                    MetaLabelCell(table, "VALID UNTIL");
                    MetaValueCell(table, q.ValidityDate ?? string.Empty);

                    MetaLabelCell(table, "PROJECT NAME");
                    table.Cell().ColumnSpan(3).Background(Colors.White)
                        .Padding(4).Text(q.ProjectName ?? string.Empty)
                        .Bold().FontSize(9);
                });
            });
        }

        // ─── CONTENT ───────────────────────────────────────────────────────────────────
        private void ComposeContent(IContainer container, QuotationRequest q, TenantInformation tenant)
        {
            container.Column(col =>
            {
                col.Spacing(6); // uniform spacing — NO manual Height() calls anywhere

                col.Item().Element(c => ComposeLiftConfig(c, q.QuotationLiftConfig));
                col.Item().Element(c => ComposeFinancials(c, q.QuotationCalculations));
                col.Item().Element(c => ComposeSpecSections(c, q.QuotationSpec));
                col.Item().Element(c => ComposeAdditionalNotes(c, q.QuotationSpec.AdditionalNotes));

                if (!string.IsNullOrWhiteSpace(tenant.TermsOfPayments))
                    col.Item().Element(c => ComposeTermsOfPayment(c, tenant.TermsOfPayments!));

                if (!string.IsNullOrWhiteSpace(tenant.SpecialNotes))
                    col.Item().Element(c => ComposeSpecialNotes(c, tenant.SpecialNotes!));

                if (!string.IsNullOrWhiteSpace(tenant.Warranty))
                    col.Item().Element(c => ComposeWarranty(c, tenant.Warranty!));
            });
        }

        // ─── LIFT CONFIG ───────────────────────────────────────────────────────────────
        private void ComposeLiftConfig(IContainer container, QuotationLiftConfig cfg)
        {
            container.Column(col =>
            {
                col.Spacing(0);
                col.Item().Background(HeaderBlue).Padding(5)
                    .Text("LIFT CONFIGURATION").Bold().FontColor(Colors.White).FontSize(8);

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.RelativeColumn(3);
                        cols.RelativeColumn(4);
                        cols.RelativeColumn(3);
                        cols.RelativeColumn(4);
                    });

                    var rows = new[]
                    {
                ("Lift Type",       cfg.LiftType       ?? string.Empty, "Drive Type",     cfg.DriveType      ?? string.Empty),
                ("Capacity",        cfg.Capacity       ?? string.Empty, "Speed",          cfg.Speed          ?? string.Empty),
                ("Stops",           cfg.Stops          ?? string.Empty, "Door Type",      cfg.DoorType       ?? string.Empty),
                ("Controller Type", cfg.ControllerType ?? string.Empty, "Cabin Finish",   cfg.CabinFinish    ?? string.Empty),
            };

                    bool alt = false;
                    foreach (var (l1, v1, l2, v2) in rows)
                    {
                        string bg = alt ? RowGray : Colors.White;
                        SpecLabelCell(table, l1, bg);
                        SpecValueCell(table, v1, bg);
                        SpecLabelCell(table, l2, bg);
                        SpecValueCell(table, v2, bg);
                        alt = !alt;
                    }
                });
            });
        }

        // ─── FINANCIALS ────────────────────────────────────────────────────────────────
        private void ComposeFinancials(IContainer container, QuotationCalculations calc)
        {
            container.Column(col =>
            {
                col.Spacing(0);
                col.Item().Background(HeaderBlue).Padding(5)
                    .Text("PRICING SUMMARY").Bold().FontColor(Colors.White).FontSize(8);

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.RelativeColumn(6);
                        cols.RelativeColumn(3);
                    });

                    FinRow(table, "Equipment Amount", calc.Amount, Colors.White);
                    FinRow(table, "Discount", calc.Discount, RowGray);
                    FinRow(table, "Sub Total", calc.SubTotal, Colors.White);
                    FinRow(table, "Installation Cost", calc.InstallationCost, RowGray);
                    FinRow(table, "Freight Cost", calc.FreightCost, Colors.White);
                    FinRow(table, "Customs Cost", calc.CustomsCost, RowGray);
                    FinRow(table, "Subcontractor Cost", calc.SubcontractorCost, Colors.White);

                    // Grand total
                    table.Cell().Background(HeaderBlue).Padding(5)
                        .Text("GRAND TOTAL (KES)").Bold().FontColor(Colors.White);
                    table.Cell().Background(HeaderBlue).Padding(5).AlignRight()
                        .Text($"KES {calc.GrandTotal:N0}").Bold().FontColor(Colors.White).FontSize(10);
                });
            });
        }

        // ─── SPEC SECTIONS ─────────────────────────────────────────────────────────────
        // Key fix: each sub-section is its own Column with Spacing(0)
        // No Height() calls, no nested fixed sizes
        private void ComposeSpecSections(IContainer container, QuotationSpecification spec)
        {
            container.Column(col =>
            {
                col.Spacing(4);

                col.Item().Background(HeaderBlue).Padding(5)
                    .Text("SURVEY SPECIFICATIONS").Bold().FontColor(Colors.White).FontSize(8);

                // Project Info
                col.Item().Element(c => SpecSubSection(c, "Project Information", new[]
                {
            ("Number of Lifts",      spec.ProjectInfo?.NumberOfLiftsRequired.ToString()       ?? "-"),
            ("Expected Capacity",    spec.ProjectInfo?.ExpectedCapacity                       ?? "-"),
            ("Stops / Floors",       spec.ProjectInfo?.NumberOfStopsFloors.ToString()         ?? "-"),
            ("Travel Height",        $"{spec.ProjectInfo?.TravelHeightMeters ?? 0} m"),
            ("Completion Timeline",  spec.ProjectInfo?.EstimatedCompletionTimeline            ?? "-"),
        }));

                // Shaft
                col.Item().Element(c => SpecSubSection(c, "Shaft & Structural Information", new[]
                {
            ("Shaft Size",           spec.ShaftStructuralInfo?.ShaftSize                          ?? "-"),
            ("Shaft Height",         $"{spec.ShaftStructuralInfo?.ShaftHeight ?? 0} m"),
            ("Pit Depth",            $"{spec.ShaftStructuralInfo?.PitDepth ?? 0} m"),
            ("Overhead / Headroom",  $"{spec.ShaftStructuralInfo?.OverheadHeightHeadroom ?? 0} m"),
            ("Core Cutting",         YesNo(spec.ShaftStructuralInfo?.CoreCuttingRequired ?? false)),
            ("Machine Room",         YesNo(spec.ShaftStructuralInfo?.MachineRoomAvailability ?? false)),
            ("Civil Works",          YesNo(spec.ShaftStructuralInfo?.CivilWorksRequired ?? false)),
        }));

                // Entrance & Doors
                col.Item().Element(c => SpecSubSection(c, "Entrance & Door Details", new[]
                {
            ("Number of Entrances",  spec.EntranceDoorDetails?.NumberOfEntrances.ToString()        ?? "-"),
            ("Door Size",            spec.EntranceDoorDetails?.DoorSize                            ?? "-"),
            ("Landing Door Finish",  spec.EntranceDoorDetails?.LandingDoorFinishPreference         ?? "-"),
        }));

                // Power
                col.Item().Element(c => SpecSubSection(c, "Power & Electrical", new[]
                {
            ("Voltage Available",        $"{spec.PowerElectricalInfo?.VoltageAvailable ?? "-"} V"),
            ("Backup Generator",         YesNo(spec.PowerElectricalInfo?.BackupGeneratorAvailable ?? false)),
            ("Dedicated Power Line",     YesNo(spec.PowerElectricalInfo?.DedicatedLiftPowerLineAvailable ?? false)),
        }));

                // Usage
                col.Item().Element(c => SpecSubSection(c, "Usage & Traffic", new[]
                {
            ("Daily Traffic",    spec.UsageTrafficInfo?.EstimatedDailyTraffic ?? "-"),
            ("Peak Usage Hours", spec.UsageTrafficInfo?.PeakUsageHours        ?? "-"),
        }));

                // Finishing
                col.Item().Element(c => SpecSubSection(c, "Finishing & Design Preferences", new[]
                {
            ("Cabin Finish",    spec.FinishingDesignPreferences?.CabinFinishPreference ?? "-"),
            ("Flooring",        spec.FinishingDesignPreferences?.FlooringPreference    ?? "-"),
            ("Ceiling Type",    spec.FinishingDesignPreferences?.CeilingType           ?? "-"),
            ("Mirror",          YesNo(spec.FinishingDesignPreferences?.MirrorRequired ?? false)),
            ("Handrails",       YesNo(spec.FinishingDesignPreferences?.HandrailsRequired ?? false)),
            ("Display Type",    spec.FinishingDesignPreferences?.DisplayTypePreference  ?? "-"),
        }));

                // Safety
                col.Item().Element(c => SpecSubSection(c, "Safety & Compliance", new[]
                {
            ("Fireman Operation",        YesNo(spec.SafetyComplianceInfo?.FiremanOperationRequired      ?? false)),
            ("Emergency Rescue System",  YesNo(spec.SafetyComplianceInfo?.EmergencyRescueSystemRequired ?? false)),
            ("CCTV",                     YesNo(spec.SafetyComplianceInfo?.CctvRequired                  ?? false)),
            ("Access Control",           YesNo(spec.SafetyComplianceInfo?.AccessControlRequired          ?? false)),
            ("Compliance Standard",      spec.SafetyComplianceInfo?.ComplianceStandardRequired           ?? "-"),
        }));

                // Maintenance
                col.Item().Element(c => SpecSubSection(c, "Maintenance & Service", new[]
                {
            ("Maintenance Contract",  YesNo(spec.MaintenanceServiceInfo?.MaintenanceContractRequired ?? false)),
            ("Existing Lift on Site", YesNo(spec.MaintenanceServiceInfo?.ExistingLiftOnSite          ?? false)),
            ("Lift Condition",        spec.MaintenanceServiceInfo?.CurrentLiftCondition               ?? "-"),
            ("Service Frequency",     spec.MaintenanceServiceInfo?.ServiceFrequencyPreference         ?? "-"),
        }));
            });
        }

        // ─── REUSABLE SUB-SECTION ──────────────────────────────────────────────────────
        // Single pattern for every spec sub-section — consistent, no size conflicts
        private void SpecSubSection(IContainer container, string title,
                                     (string Label, string Value)[] rows)
        {
            container.Column(col =>
            {
                col.Spacing(0);

                // Sub-section title
                col.Item().Background(LightBlue).PaddingVertical(3).PaddingHorizontal(5)
                    .Text(title).Bold().FontSize(8);

                // Rows
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.RelativeColumn(4);
                        cols.RelativeColumn(6);
                    });

                    bool alt = false;
                    foreach (var (label, value) in rows)
                    {
                        string bg = alt ? RowGray : Colors.White;
                        table.Cell().Background(bg)
                            .BorderBottom(1).BorderColor("#EEEEEE")
                            .Padding(4).Text(label).FontColor("#555555").FontSize(8);
                        table.Cell().Background(bg)
                            .BorderBottom(1).BorderColor("#EEEEEE")
                            .Padding(4).Text(value).Bold().FontSize(8);
                        alt = !alt;
                    }
                });
            });
        }

        // ─── ADDITIONAL NOTES ──────────────────────────────────────────────────────────
        private void ComposeAdditionalNotes(IContainer container, AdditionalNotes? notes)
        {
            if (notes is null) return;

            container.Column(col =>
            {
                col.Spacing(0);
                col.Item().Background(HeaderBlue).Padding(5)
                    .Text("ADDITIONAL NOTES").Bold().FontColor(Colors.White).FontSize(8);

                col.Item().Border(1).BorderColor(LightBlue).Padding(8).Column(c =>
                {
                    c.Spacing(5);
                    NoteRow(c, "Special Requirements", notes.SpecialRequirements);
                    NoteRow(c, "Site Challenges", notes.SiteChallenges);
                    NoteRow(c, "Customer Comments", notes.CustomerComments);
                    NoteRow(c, "Surveyor Remarks", notes.SurveyorRemarks);
                });
            });
        }

        // ─── TENANT SECTIONS ───────────────────────────────────────────────────────────
        private void ComposeWarranty(IContainer container, string warrantyText)
        {
            container.Background(LightBlue).Padding(8).Column(c =>
            {
                c.Spacing(3);
                c.Item().Text("Product and Service Warranty").Bold().Italic().FontSize(8);
                c.Item().Text(warrantyText).FontSize(8);
            });
        }

        private void ComposeTermsOfPayment(IContainer container, string terms)
        {
            container.Column(col =>
            {
                col.Spacing(0);
                col.Item().Background(HeaderBlue).Padding(5)
                    .Text("TERMS OF PAYMENT").Bold().FontColor(Colors.White).FontSize(8);
                col.Item().Border(1).BorderColor(LightBlue).Padding(8)
                    .Text(terms).FontSize(8);
            });
        }

        private void ComposeSpecialNotes(IContainer container, string notes)
        {
            container.Column(col =>
            {
                col.Spacing(0);
                col.Item().Background(HeaderBlue).Padding(5)
                    .Text("SPECIAL NOTES").Bold().FontColor(Colors.White).FontSize(8);
                col.Item().Border(1).BorderColor(LightBlue).Padding(8)
                    .Text(notes).FontSize(8);
            });
        }

        // ─── FOOTER ────────────────────────────────────────────────────────────────────
        private void ComposeFooter(IContainer container, TenantInformation tenant)
        {
            container.BorderTop(1).BorderColor(HeaderBlue).PaddingTop(4)
                .Row(row =>
                {
                    row.RelativeItem().Text(tenant.Email ?? string.Empty).FontSize(7).Italic();
                    row.RelativeItem().AlignCenter().Text(tenant.PhoneNumber ?? string.Empty).FontSize(7);
                    row.RelativeItem().AlignRight().Text(tenant.Name ?? string.Empty).FontSize(7).Italic();
                });
        }

        // ─── HELPERS ───────────────────────────────────────────────────────────────────
        private static void FinRow(TableDescriptor t, string label, decimal value, string bg)
        {
            t.Cell().Background(bg).Padding(4).Text(label).FontSize(8);
            t.Cell().Background(bg).Padding(4).AlignRight()
                .Text($"KES {value:N0}").FontSize(8);
        }

        private static void NoteRow(ColumnDescriptor c, string label, string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;
            c.Item().Column(inner =>
            {
                inner.Item().Text(label).Bold().FontSize(7);
                inner.Item().Text(value).FontSize(8);
            });
        }

        private static void MetaLabelCell(TableDescriptor t, string label) =>
            t.Cell().Background(HeaderBlue).Padding(4)
                .Text(label).Bold().FontColor(Colors.White).FontSize(7);

        private static void MetaValueCell(TableDescriptor t, string value) =>
            t.Cell().Background(Colors.White).Padding(4).Text(value).Bold().FontSize(8);

        private static void SectionTitle(ColumnDescriptor col, string title) =>
            col.Item().Background(LightBlue).PaddingVertical(3).PaddingHorizontal(5)
                .Text(title).Bold().FontSize(8);

        private static void SpecLabelCell(TableDescriptor t, string label, string bg) =>
            t.Cell().Background(bg).Padding(4).Text(label).FontColor("#555555").FontSize(7);

        private static void SpecValueCell(TableDescriptor t, string value, string bg) =>
            t.Cell().Background(bg).Padding(4).Text(value).Bold().FontSize(8);

        private static string YesNo(bool value) => value ? "Yes" : "No";

        private static byte[] FetchImageBytes(string url)
        {
            try
            {
                using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
                return client.GetByteArrayAsync(url).GetAwaiter().GetResult();
            }
            catch
            {
                return Array.Empty<byte>();
            }
        }
        }

        // Fetches logo bytes once — returns empty array gracefully if URL fails


        //// ── Entry point ───────────────────────────────────────────────────────────
        //public byte[] GeneratePdf(QuotationDocument quotation ,Guid tenantId)
        //{
        //    QuestPDF.Settings.License = LicenseType.Community;

        //    return Document.Create(container =>
        //    {
        //        container.Page(page =>
        //        {
        //            page.Size(PageSizes.A4);
        //            page.Margin(30);
        //            page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Arial"));

        //            page.Header().Element(c => ComposeHeader(c, quotation, tenantId));
        //            page.Content().Element(c => ComposeContent(c, quotation));
        //            page.Footer().Element(c=>ComposeFooter(c,tenantId));
        //        });
        //    }).GeneratePdf();
        //}

        //// ── Header ────────────────────────────────────────────────────────────────
        //private void ComposeHeader(IContainer container, QuotationDocument q, Guid tenantId)
        //{

        //    var tenant = _context.Tenants.Where(t => t.Id == tenantId).FirstOrDefault();
        //    container.Column(col =>
        //    {   

        //        // ── Brand bar (logo + company text) ───────────────────────────────
        //        col.Item().Background(HeaderBlue).Padding(10).Row(row =>
        //        {
        //            // Logo column
        //            byte[]? logoBytes = TryLoadLogo();
        //            if (logoBytes != null)
        //            {
        //                row.ConstantItem(90).PaddingRight(12).AlignMiddle()
        //                    .Image(_logoBase64).FitArea();
        //            }

        //            // Company name + address
        //            row.RelativeItem().Column(c =>
        //            {
        //                c.Item().Text(tenant.Name)
        //                    .FontSize(18).Bold().FontColor(Colors.White);
        //                c.Item().Text(tenant.Name)
        //                    .FontSize(9).FontColor(Colors.White).Italic();
        //                c.Item().Text(tenant.Address)
        //                    .FontSize(8).FontColor(Colors.White);
        //            });
        //        });

        //        col.Item().Height(8);

        //        // ── Quotation meta table ──────────────────────────────────────────
        //        col.Item().Border(1).BorderColor(HeaderBlue).Table(table =>
        //        {
        //            table.ColumnsDefinition(cols =>
        //            {
        //                cols.RelativeColumn(2);
        //                cols.RelativeColumn(4);
        //                cols.RelativeColumn(2);
        //                cols.RelativeColumn(3);
        //            });

        //            // Row 1
        //            MetaCell(table, "QUOTATION REF#", HeaderBlue);
        //            MetaValueCell(table, q.QuotationRef);
        //            MetaCell(table, "QUOTATION DATE", HeaderBlue);
        //            MetaValueCell(table, q.QuotationDate.ToString("dd MMM yyyy").ToUpper());

        //            // Row 2
        //            MetaCell(table, "COUNTRY/CITY", HeaderBlue);
        //            MetaValueCell(table, q.Country);
        //            MetaCell(table, "PRODUCTION TYPE", HeaderBlue);
        //            MetaValueCell(table, q.ProductionType);



        //            // Row 3 – full-width project name
        //            MetaCell(table, "PROJECT NAME", HeaderBlue);
        //            table.Cell().ColumnSpan(3).Background(Colors.White)
        //                .Padding(5).Text(q.ProjectName).Bold();

        //        });
        //    });
        //}

        //// ── Content ───────────────────────────────────────────────────────────────
        //private void ComposeContent(IContainer container, QuotationDocument q)
        //{
        //    container.Column(col =>
        //    {
        //        col.Item().Height(10);

        //        // ── Pricing table ─────────────────────────────────────────────────
        //        col.Item().Text("PRICE").Bold().FontSize(10);
        //        col.Item().Height(4);

        //        col.Item().Table(table =>
        //        {
        //            table.ColumnsDefinition(cols =>
        //            {
        //                cols.RelativeColumn(2);   // Product
        //                cols.RelativeColumn(2);   // Model
        //                cols.RelativeColumn(4);   // Basic Specs
        //                cols.RelativeColumn(1);   // Qty
        //                cols.RelativeColumn(2);   // Unit Price USD
        //                cols.RelativeColumn(2);   // Sub Total KES
        //            });

        //            string[] headers = { "PRODUCT", "MODEL", "BASIC SPECS.", "QTY",
        //                                 "UNIT PRICE/USD", "SUB TOTAL/KES" };
        //            foreach (var h in headers)
        //                table.Cell().Background(HeaderBlue).Padding(5).AlignCenter()
        //                    .Text(h).Bold().FontColor(Colors.White).FontSize(8);

        //            bool alt = false;
        //            foreach (var item in q.LineItems)
        //            {
        //                string bg = alt ? RowGray : Colors.White;
        //                table.Cell().Background(bg).Padding(5).Text(item.Product);
        //                table.Cell().Background(bg).Padding(5).Text(item.Model);
        //                table.Cell().Background(bg).Padding(5).Text(item.BasicSpecs);
        //                table.Cell().Background(bg).Padding(5).AlignCenter()
        //                    .Text(item.Quantity.ToString());
        //                table.Cell().Background(bg).Padding(5).AlignRight()
        //                    .Text(item.UnitPriceUsd.ToString("N0"));
        //                table.Cell().Background(bg).Padding(5).AlignRight()
        //                    .Text(item.SubTotalKes.ToString("N0"));
        //                alt = !alt;
        //            }
        //        });

        //        col.Item().Height(10);

        //        // ── Notes ─────────────────────────────────────────────────────────
        //        col.Item().Background(LightBlue).Padding(8).Column(c =>
        //        {
        //            c.Item().Text("NOTE:").Bold();
        //            c.Item().Text($"1 USD = {q.UsdToKesRate} KES").Bold().Italic();
        //            c.Item().Text($"1. Valid for {q.ValidityDays} days. " +
        //                          "If exchange rate change exceeds 3%, price will be adjusted.");
        //            c.Item().Text("2. Above is net equipment price, " +
        //                          "Certificate & Applicable taxes to port of Mombasa.");
        //        });

        //        col.Item().Height(10);

        //        // ── Payment Terms ─────────────────────────────────────────────────
        //        col.Item().Text("TERMS OF PAYMENT:").Bold();
        //        col.Item().PaddingLeft(15).Column(c =>
        //        {
        //            c.Item().Text("1. To facilitate Manufacturing — 50%");
        //            c.Item().Text("2. Delivery of Material to port of Mombasa — 50%");
        //        });

        //        col.Item().Height(10);

        //        // ── Warranty ──────────────────────────────────────────────────────
        //        col.Item().Text("Product and Service Warranty").Bold().Italic();
        //        col.Item().Height(4);
        //        col.Item().Text(
        //            "The product warranty is one year. Service warranty provided by FDK Elevators " +
        //            "Limited covers six (6) months from the official date of handover. During this " +
        //            "period, the company shall provide service support, inspection, and maintenance " +
        //            "assistance. This warranty does not cover consumables, physical damage, power " +
        //            "supply failure, water ingress, fire, acts of God, misuse, negligence, or " +
        //            "unauthorized modifications."
        //        ).FontSize(8);

        //        col.Item().Height(10);

        //        // ── Installation Fee ──────────────────────────────────────────────
        //        col.Item().Table(table =>
        //        {
        //            table.ColumnsDefinition(cols =>
        //            {
        //                cols.RelativeColumn(3);
        //                cols.RelativeColumn(5);
        //                cols.RelativeColumn(2);
        //            });

        //            table.Cell().RowSpan(3).Background(LightBlue).Padding(6)
        //                .AlignMiddle().Text("INSTALLATION FEE FOR EACH UNIT").Bold();

        //            table.Cell().Padding(5)
        //                .Text("1. When materials arrive at site — 50% (150,000)");
        //            table.Cell().RowSpan(3).Background(LightBlue).Padding(6)
        //                .AlignMiddle().AlignCenter().Text("300,000 KES").Bold();

        //            table.Cell().Padding(5)
        //                .Text("2. Installation of guide rails and cabin — 25% (75,000)");
        //            table.Cell().Padding(5)
        //                .Text("3. On handover — 25% (75,000)");
        //        });

        //        col.Item().Height(10);

        //        // ── Specifications ────────────────────────────────────────────────
        //        if (q.Specifications.Any())
        //        {
        //            col.Item().Background(HeaderBlue).Padding(6)
        //                .Text("SPECIFICATIONS").Bold().FontColor(Colors.White);

        //            col.Item().Table(table =>
        //            {
        //                table.ColumnsDefinition(cols =>
        //                {
        //                    cols.ConstantColumn(25);
        //                    cols.RelativeColumn(3);
        //                    cols.RelativeColumn(5);
        //                });

        //                bool alt2 = false;
        //                foreach (var spec in q.Specifications)
        //                {
        //                    string bg = alt2 ? RowGray : Colors.White;
        //                    table.Cell().Background(bg).Padding(4)
        //                        .Text(spec.Number.ToString());
        //                    table.Cell().Background(bg).Padding(4)
        //                        .Text(spec.Label);
        //                    table.Cell().Background(bg).Padding(4)
        //                        .Text(spec.Value).Bold();
        //                    alt2 = !alt2;
        //                }
        //            });
        //        }
        //    });
        //}

        //// ── Footer ────────────────────────────────────────────────────────────────
        //private void ComposeFooter(IContainer container, Guid tenantId)
        //{
        //    var tenant = _context.Tenants.Where(t => t.Id == tenantId).FirstOrDefault();
        //    container.BorderTop(1).BorderColor(HeaderBlue).PaddingTop(6)
        //        .Row(row =>
        //        {
        //            row.RelativeItem()
        //                .Text(tenant.Name).FontSize(8).Italic();
        //            row.RelativeItem().AlignCenter()
        //                .Text(tenant.PhoneNumber).FontSize(8);
        //            row.RelativeItem().AlignRight()
        //                .Text(tenant.Email).FontSize(8).Italic();
        //        });
        //}

        //// ── Logo loader ───────────────────────────────────────────────────────────
        //private byte[]? TryLoadLogo()
        //{
        //    // 1. Try file path first
        //    if (!string.IsNullOrWhiteSpace(_logoPath) && File.Exists(_logoPath))
        //        return File.ReadAllBytes(_logoPath);

        //    // 2. Fall back to Base64 blob
        //    if (!string.IsNullOrWhiteSpace(_logoBase64))
        //    {
        //        try { return Convert.FromBase64String(_logoBase64); }
        //        catch { /* invalid Base64 – skip */ }
        //    }

        //    return null;  // No logo available → header renders without image
        //}

        //// ── Cell helpers ──────────────────────────────────────────────────────────
        //private static void MetaCell(TableDescriptor table, string label, string color)
        //{
        //    table.Cell().Background(color).Padding(5)
        //        .Text(label).Bold().FontColor(Colors.White).FontSize(8);
        //}

        //private static void MetaValueCell(TableDescriptor table, string value)
        //{
        //    table.Cell().Background(Colors.White).Padding(5)
        //        .Text(value).Bold().FontSize(9);
        //}

    }