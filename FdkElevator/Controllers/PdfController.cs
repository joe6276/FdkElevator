using Azure.Storage.Blobs;
using FdkElevator.DTOS.PDFDTO;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Quotations;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdf _pdf;
        private readonly IBlob _blob;
        private readonly IQuotation _quotation;

        public PdfController(IPdf pdf, IBlob blob, IQuotation quotation)
        {
            _pdf = pdf;
            _blob = blob;
            _quotation = quotation;
        }

        [HttpPost("generate-pdf/test/{QuotationID}")]
        public async Task<IActionResult> GeneratePdfTest(Guid QuotationID)
        {
            var tenantInformation = new TenantInformation
            {
                Name = "FDK Elevators Ltd",
                Logo_URL = "https://tse3.mm.bing.net/th/id/OIP.Sc-pGDkmKH6dLZgbWk-3uAHaHa?r=0&rs=1&pid=ImgDetMain&o=7&rm=3",
                Address = "Westlands Business Park, Waiyaki Way, Nairobi, Kenya",
                PhoneNumber = "+254712345678",
                Email = "info@fdkelevators.com",
                isActive = true,
                Warranty = "24 months warranty on all installed elevator systems.",
                TermsOfPayments = "50% deposit upon order confirmation, 40% before installation, and 10% upon project completion.",
                SpecialNotes = "Routine maintenance for the first year is included at no additional cost."
            };
            var response = await _quotation.GetQuotationDocument(QuotationID);

            byte[] url = _pdf.GeneratePdf(response, tenantInformation);

           var urlBlob = await _blob.UploadAsync(url, $"{response.ProjectName}_{response.QuotationNumber}.pdf", "application/pdf");

            return Ok(new
            {
                urlBlob
            });
        }

        // ─── Dummy Data ────────────────────────────────────────────────────────────
        private static QuotationDocument GetDummyQuotation() => new QuotationDocument
        {
            QuotationRef = "FJ260550",
            QuotationDate = new DateTime(2026, 5, 25),
            ProjectName = "SUNVALLEY PHASE ONE HSE NO 72",
            Country = "KENYA",
            ProductionType = "HYDRAULIC PLATFORM LIFT",
            UsdToKesRate = 130,
            ValidityDays = 30,

            LineItems = new List<QuotationLineItem>
        {
            new QuotationLineItem
            {
                Product      = "HOME LIFT",
                Model        = "TKJ",
                BasicSpecs   = "G+1  0.4M/S  2F/2S/2D",
                Quantity     = 1,
                UnitPriceUsd = 25_135,
                SubTotalKes  = 3_267_550
            },
            new QuotationLineItem
            {
                Product      = "HOME LIFT",
                Model        = "TKJ",
                BasicSpecs   = "G+2  0.4M/S  3F/3S/3D",
                Quantity     = 1,
                UnitPriceUsd = 28_038,
                SubTotalKes  = 3_644_940
            }
        },

            Specifications = new List<QuotationSpec>
        {
            new QuotationSpec { Number = 1,  Label = "Shaft",             Value = "2780*900 – Aluminum glass shaft"          },
            new QuotationSpec { Number = 2,  Label = "Model",             Value = "TBJ400/0.4 (Including ARD)"               },
            new QuotationSpec { Number = 3,  Label = "Rated Capacity",    Value = "320 KG"                                   },
            new QuotationSpec { Number = 4,  Label = "Persons",           Value = "3 persons"                                },
            new QuotationSpec { Number = 5,  Label = "Floors/Stops/Doors",Value = "2F/2S/2D  |  3F/3S/3D"                  },
            new QuotationSpec { Number = 6,  Label = "Speed",             Value = "0.4 m/s"                                  },
            new QuotationSpec { Number = 7,  Label = "Control System",    Value = "Simplex full collective"                  },
            new QuotationSpec { Number = 8,  Label = "Drive System",      Value = "VVVF"                                     },
            new QuotationSpec { Number = 9,  Label = "Traction Machine",  Value = "Gearless Machine"                         },
            new QuotationSpec { Number = 10, Label = "Car Size",          Value = "800 × 1100 × 2200 mm"                    },
            new QuotationSpec { Number = 11, Label = "Door Size",         Value = "900 × 2000 mm Auto swing door, 2 panels"  },
            new QuotationSpec { Number = 12, Label = "Travel Height",     Value = "2820 mm  |  2820 + 2730 mm"               },
            new QuotationSpec { Number = 13, Label = "Floor Mark",        Value = "G+1  |  G+1+2"                            },
            new QuotationSpec { Number = 14, Label = "Roping",            Value = "2:1"                                      },
            new QuotationSpec { Number = 15, Label = "Car Entrances",     Value = "Single"                                   },
            new QuotationSpec { Number = 16, Label = "Main Power Supply", Value = "AC 380V, 3Ph, 50Hz"                       },
            new QuotationSpec { Number = 17, Label = "Light Power Supply",Value = "AC 220V, 1Ph, 50Hz"                       },
            new QuotationSpec { Number = 18, Label = "Pit Depth",         Value = "500 mm"                                   },
            new QuotationSpec { Number = 19, Label = "Overhead",          Value = "2800 mm"                                  },
            new QuotationSpec { Number = 20, Label = "Cabin Rear Wall",   Value = "Glass with Aluminum frame panel"          },
            new QuotationSpec { Number = 21, Label = "Cabin Side Wall",   Value = "Glass with Aluminum frame"                },
            new QuotationSpec { Number = 22, Label = "Cabin Door",        Value = "Without"                                  },
            new QuotationSpec { Number = 23, Label = "Landing Door",      Value = "Glass with Aluminum frame (all floors)"   },
            new QuotationSpec { Number = 24, Label = "Door Jamb",         Value = "Aluminum (all floors)"                    },
            new QuotationSpec { Number = 25, Label = "Ceiling",           Value = "Hairline stainless steel + acrylic"       },
            new QuotationSpec { Number = 26, Label = "Floor",             Value = "PVC"                                      },
            new QuotationSpec { Number = 27, Label = "COP",               Value = "See product picture"                      },
            new QuotationSpec { Number = 28, Label = "LOP",               Value = "F-WH12"                                   },
            new QuotationSpec { Number = 29, Label = "Handrail",          Value = "1 pc round type handrail (HSS)"           }
        },

            StandardFunctions = new List<string>
        {
            "VVVF Drive",
            "VVVF Drive for door operator",
            "Emergency Car Lighting",
            "Designated Parking",
            "Automatic Bypass",
            "Overload Holding Stop",
            "Up/Down Overrun and Final Limit",
            "Car Ventilation Shut Off Automatic",
            "Car Light Shut Off Automatic",
            "Power On Re-leveling",
            "Anti-stall Timer Protection",
            "Start Protection Control",
            "Inspection Operation",
            "Inching Operation",
            "Safety Stop",
            "Self-Diagnosis of Breakdown",
            "Reopen Door Closing",
            "Automatically Adjust Door Open Time",
            "Reopen with Hall Call",
            "Express Door Closing",
            "Car Stop and Doors Open",
            "Car Arrival Chime",
            "Five-way Communication Device",
            "Emergency Bell",
            "Floor and Direction Indicator in Car",
            "Over Speed Protection Device",
            "Fire Emergency Return",
            "Command Registered Canceling",
            "Main Floor Shut Off",
            "Light Curtain Protection (Full Height)",
            "Floor and Direction Indicator at Hall",
            "Pre-load Start"
        }
        };
    }
}

