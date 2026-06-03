

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace FdkElevator.Services
{
    public class DocService
    {

    }

    //public class DocService
    //{

    //    private readonly DocumentControlRequest _req;

    //    // ── Palette ───────────────────────────────────────────────────────────────
    //    private static readonly string NavyBlue = "#1B3A6B";
    //    private static readonly string LightBlue = "#D6E4F7";
    //    private static readonly string MidBlue = "#4A7CC1";
    //    private static readonly string RowAlt = "#F2F6FC";
    //    private static readonly string Border = "#B0C4DE";
    //    private static readonly string White = "#FFFFFF";
    //    private static readonly string BodyText = "#1A1A2E";

    //    public DocumentMetadata GetMetadata() => new()
    //    {
    //        Title = "Template Register and Document Control Matrix",
    //        Author = _req.Header.PreparedBy,
    //        Subject = $"Project {_req.Header.ProjectId} – {_req.Header.ProjectName}",
    //        CreationDate = DateTime.Now
    //    };
    //    public void Compose(IDocumentContainer container)
    //    {
    //        container.Page(page =>
    //        {
    //            page.Size(PageSizes.A4.Landscape());
    //            page.MarginHorizontal(18);
    //            page.MarginVertical(14);
    //            page.DefaultTextStyle(t => t.FontFamily("Arial").FontSize(8).FontColor(BodyText));

    //            page.Header().Element(ComposeHeader);
    //            page.Content().Element(ComposeContent);
    //            page.Footer().Element(ComposeFooter);
    //        });
    //    }

    //    private void ComposeHeader(IContainer c)
    //    {
    //        c.Column(col =>
    //        {
    //            // Title bar
    //            col.Item().Table(t =>
    //            {
    //                t.ColumnsDefinition(cd =>
    //                {
    //                    cd.RelativeColumn(3);
    //                    cd.RelativeColumn(2);
    //                    cd.RelativeColumn(1.5f);
    //                    cd.RelativeColumn(1.5f);
    //                });

    //                HeaderCell(t, "LIFT INSTALLATION ERP TEMPLATE", isTitle: true);
    //                HeaderCell(t, $"Code: LIFT-DOC-000");
    //                HeaderCell(t, "Version: V1.0");
    //                HeaderCell(t, "Status: Controlled");
    //            });

    //            // Sub-title bar
    //            col.Item()
    //               .Background(MidBlue)
    //               .Padding(5)
    //               .AlignCenter()
    //               .Text("TEMPLATE REGISTER AND DOCUMENT CONTROL MATRIX")
    //               .FontColor(White).FontSize(11).Bold();

    //            // Category note
    //            col.Item().PaddingTop(3).PaddingBottom(6)
    //               .Text("Category: 00_Master_Register_and_Control  |  Use after project activation until handover/warranty start")
    //               .FontSize(7).Italic().FontColor("#555577");
    //        });
    //    }

    //    private static void HeaderCell(TableDescriptor t, string text, bool isTitle = false)
    //    {
    //        t.Cell()
    //         .Border(0.5f).BorderColor(Border)
    //         .Background(NavyBlue)
    //         .Padding(6)
    //         .AlignCenter()
    //         .Text(text)
    //         .FontColor(White)
    //         .FontSize(isTitle ? 10 : 8)
    //         .Bold();
    //    }

    //    // ── PAGE CONTENT ─────────────────────────────────────────────────────────

    //    private void ComposeContent(IContainer c)
    //    {
    //        c.Column(col =>
    //        {
    //            col.Spacing(10);

    //            col.Item().Element(ComposePurpose);
    //            col.Item().Element(ComposeSectionA);
    //            col.Item().Element(ComposeSectionB);
    //            col.Item().Element(ComposeSectionC);
    //            col.Item().Element(ComposeSectionD);
    //            col.Item().Element(ComposeSystemNote);
    //        });
    //    }

    //    private void ComposePurpose(IContainer c)
    //    {
    //        c.Column(col =>
    //        {
    //            SectionHeading(col, "Purpose and Applicability");
    //            col.Item().Row(row =>
    //            {
    //                row.RelativeItem().Column(inner =>
    //                {
    //                    inner.Item().Text(t =>
    //                    {
    //                        t.Span("Purpose: ").Bold();
    //                        t.Span("Controls every template used from installation project activation to handover and warranty monitoring.");
    //                    });
    //                });
    //                row.ConstantItem(20);
    //                row.RelativeItem().Column(inner =>
    //                {
    //                    inner.Item().Text(t =>
    //                    {
    //                        t.Span("Applicable to: ").Bold();
    //                        t.Span("All installation projects and all lift types.");
    //                    });
    //                });
    //            });
    //        });
    //    }



    //    private void ComposeSectionA(IContainer c)
    //    {
    //        c.Column(col =>
    //        {
    //            SectionHeading(col, "A. Document Header / ERP Record Fields");

    //            col.Item().Table(t =>
    //            {
    //                t.ColumnsDefinition(cd =>
    //                {
    //                    cd.RelativeColumn(2);
    //                    cd.RelativeColumn(3);
    //                    cd.ConstantColumn(55);
    //                    cd.RelativeColumn(2);
    //                });

    //                // Header row
    //                TableHeaderRow(t, "Field", "Input / Value", "Required", "ERP Field Type");

    //                var rows = new[]
    //                {
    //                ("Project ID",                   _req.Header.ProjectId,                 "Yes",         "Auto / Text"),
    //                ("Project Name / Building",      _req.Header.ProjectName,               "Yes",         "Text"),
    //                ("Lift ID / Unit Number",        _req.Header.LiftIdUnitNumber,          "Yes",         "Dropdown / Text"),
    //                ("Lift Type",                    _req.Header.LiftType.ToString(),       "Yes",         "Dropdown"),
    //                ("Site Location / Zone / Floor", _req.Header.SiteLocationZoneFloor,     "Yes",         "Text"),
    //                ("Prepared By",                  _req.Header.PreparedBy,                "Yes",         "User"),
    //                ("Prepared Date",                _req.Header.PreparedDate.ToString("dd-MMM-yyyy"), "Yes", "Date"),
    //                ("Responsible Team",             _req.Header.ResponsibleTeam,           "Yes",         "Dropdown"),
    //                ("Reviewer / Approver",          _req.Header.ReviewerApprover ?? "",    "Conditional", "User"),
    //                ("Document Owner",               _req.Header.DocumentOwner,             "Yes",         "User"),
    //                ("Effective Date",               _req.Header.EffectiveDate.ToString("dd-MMM-yyyy"), "Yes", "Date"),
    //                ("Revision Reason",              _req.Header.RevisionReason ?? "",      "Conditional", "Long Text"),
    //            };

    //                for (int i = 0; i < rows.Length; i++)
    //                {
    //                    var bg = i % 2 == 0 ? White : RowAlt;
    //                    var (field, value, req, erpType) = rows[i];
    //                    TableDataCell(t, field, bg, bold: true);
    //                    TableDataCell(t, value, bg);
    //                    TableDataCell(t, req, bg, center: true);
    //                    TableDataCell(t, erpType, bg);
    //                }
    //            });
    //        });
    //    }


    //    private void ComposeSectionB(IContainer c)
    //    {
    //        c.Column(col =>
    //        {
    //            SectionHeading(col, "B. Control, Download, Signing and Upload Rules");

    //            var rules = new[]
    //            {
    //            "The ERP shall allow the user to generate this template from the correct project, lift unit, phase and task screen.",
    //            "The generated DOCX/PDF shall carry project ID, lift ID, version number, issue date and responsible approver.",
    //            "Signed/scanned copies, photos, test records, supplier certificates and authority approvals shall be uploaded back against the same task record.",
    //            "A task cannot move to Approved/Completed where mandatory checklist items, signatures, evidence files or approval gates are missing.",
    //            "Rejected documents shall create a correction task with reason, responsible person, due date and resubmission requirement.",
    //        };

    //            foreach (var rule in rules)
    //            {
    //                col.Item().Row(row =>
    //                {
    //                    row.ConstantItem(14).AlignMiddle()
    //                       .Text("•").FontSize(10).FontColor(MidBlue);
    //                    row.RelativeItem().Text(rule);
    //                });
    //            }
    //        });
    //    }

    //    private void ComposeSectionC(IContainer c)
    //    {
    //        c.Column(col =>
    //        {
    //            SectionHeading(col, "C. Operational Checklist / Validation Items");

    //            col.Item().Table(t =>
    //            {
    //                t.ColumnsDefinition(cd =>
    //                {
    //                    cd.ConstantColumn(28);
    //                    cd.RelativeColumn(5);
    //                    cd.ConstantColumn(35);
    //                    cd.ConstantColumn(35);
    //                    cd.ConstantColumn(35);
    //                    cd.RelativeColumn(2.5f);
    //                    cd.RelativeColumn(3);
    //                });

    //                TableHeaderRow(t, "No.", "Checklist Item / Control Point",
    //                    "Pass", "Fail", "N/A", "Evidence / Upload Required", "Remarks / Corrective Action");

    //                for (int i = 0; i < _req.ChecklistItems.Count; i++)
    //                {
    //                    var item = _req.ChecklistItems[i];
    //                    var bg = i % 2 == 0 ? White : RowAlt;

    //                    TableDataCell(t, item.No.ToString(), bg, center: true);
    //                    TableDataCell(t, item.ChecklistItemText, bg);
    //                    CheckboxCell(t, item.Result == CheckResult.Pass, bg);
    //                    CheckboxCell(t, item.Result == CheckResult.Fail, bg);
    //                    CheckboxCell(t, item.Result == CheckResult.NA, bg);
    //                    TableDataCell(t, item.EvidenceUploadRequired ?? "", bg);
    //                    TableDataCell(t, item.RemarksCorrectiveAction ?? "", bg);
    //                }
    //            });
    //        });
    //    }

    //    private void ComposeSectionD(IContainer c)
    //    {
    //        c.Column(col =>
    //        {
    //            SectionHeading(col, "D. Signatures and Approval");

    //            col.Item().Table(t =>
    //            {
    //                t.ColumnsDefinition(cd =>
    //                {
    //                    cd.RelativeColumn(2.5f);
    //                    cd.RelativeColumn(2);
    //                    cd.RelativeColumn(2);
    //                    cd.RelativeColumn(2);
    //                    cd.RelativeColumn(1.5f);
    //                });

    //                TableHeaderRow(t, "Party", "Name", "Designation", "Signature / Stamp", "Date");

    //                for (int i = 0; i < _req.Signatures.Count; i++)
    //                {
    //                    var sig = _req.Signatures[i];
    //                    var bg = i % 2 == 0 ? White : RowAlt;

    //                    TableDataCell(t, sig.Party, bg, bold: true);
    //                    TableDataCell(t, sig.Name ?? "", bg);
    //                    TableDataCell(t, sig.Designation ?? "", bg);
    //                    TableDataCell(t, sig.SignatureStamp ?? "", bg);
    //                    TableDataCell(t, sig.Date?.ToString("dd-MMM-yyyy") ?? "", bg, center: true);
    //                }
    //            });
    //        });
    //    }

    //    private static void ComposeSystemNote(IContainer c)
    //    {
    //        c.Background(LightBlue)
    //         .Border(0.5f).BorderColor(MidBlue)
    //         .Padding(6)
    //         .Text("System rule: this document is valid only when linked to an active lift installation project record and uploaded with required evidence.")
    //         .Italic().FontSize(7.5f).FontColor(NavyBlue);
    //    }

    //    // ── PAGE FOOTER ──────────────────────────────────────────────────────────

    //    private void ComposeFooter(IContainer c)
    //    {
    //        c.BorderTop(0.5f).BorderColor(Border).PaddingTop(4).Row(row =>
    //        {
    //            row.RelativeItem().Text($"Project: {_req.Header.ProjectId}  |  Lift: {_req.Header.LiftIdUnitNumber}  |  Owner: {_req.Header.DocumentOwner}")
    //               .FontSize(7).FontColor("#666688");
    //            row.AutoItem().Text(x =>
    //            {
    //                x.Span("Page ").FontSize(7).FontColor("#666688");
    //                x.CurrentPageNumber().FontSize(7).FontColor("#666688");
    //                x.Span(" of ").FontSize(7).FontColor("#666688");
    //                x.TotalPages().FontSize(7).FontColor("#666688");
    //            });
    //        });
    //    }


    //    private static void SectionHeading(ColumnDescriptor col, string title)
    //    {
    //        col.Item()
    //           .Background(NavyBlue)
    //           .Padding(5)
    //           .Text(title)
    //           .FontColor(White)
    //           .FontSize(9)
    //           .Bold();
    //    }

    //    private static void TableHeaderRow(TableDescriptor t, params string[] headers)
    //    {
    //        foreach (var h in headers)
    //        {
    //            t.Cell()
    //             .Border(0.5f).BorderColor(Border)
    //             .Background(MidBlue)
    //             .Padding(4)
    //             .AlignCenter()
    //             .Text(h)
    //             .FontColor(White)
    //             .FontSize(8)
    //             .Bold();
    //        }
    //    }

    //    private static void TableDataCell(TableDescriptor t, string text, string bg,
    //        bool bold = false, bool center = false)
    //    {
    //        var cell = t.Cell()
    //                    .Border(0.5f).BorderColor(Border)
    //                    .Background(bg)
    //                    .Padding(4);

    //        var aligned = center ? cell.AlignCenter() : cell.AlignLeft();

    //        var txt = aligned.Text(text).FontSize(8);
    //        if (bold) txt.Bold();
    //    }

    //    private static void CheckboxCell(TableDescriptor t, bool ticked, string bg)
    //    {
    //        t.Cell()
    //         .Border(0.5f).BorderColor(Border)
    //         .Background(bg)
    //         .Padding(4)
    //         .AlignCenter()
    //         .Text(ticked ? "☑" : "☐")
    //         .FontSize(10);
    //    }
    //}
}
