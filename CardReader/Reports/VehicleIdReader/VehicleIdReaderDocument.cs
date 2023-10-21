using System;
using CardReader.Core.Model.VehicleIdReader;
using CardReader.Core.Service.Resources;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CardReader.Reports.VehicleIdReader
{
    internal class VehicleIdReaderDocument : IDocument
    {
        private VehicleIdData Model { get; }

        private readonly IApplicationResources resources;

        public VehicleIdReaderDocument(VehicleIdData model, IApplicationResources resources)
        {
            Model = model;
            this.resources = resources;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontFamily("Open Sans"));

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().Element(ComposeFooter);
                });
        }

        private void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(12).SemiBold();

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Height(50).AlignCenter().Text(resources.GetString("VehicleIdDocumentTitle")).Style(titleStyle);
                });
            });
        }

        private void ComposeContent(IContainer container)
        {
            container.Row(row =>
            {
                row.Spacing(10);

                row.RelativeItem().Column(ComposeColumn0);
                row.RelativeItem().Column(ComposeColumn1);
                row.RelativeItem().Column(ComposeColumn2);
                row.RelativeItem().Column(ComposeColumn3);
            });
        }

        private void ComposeFooter(IContainer container)
        {
            var footerStyle = TextStyle.Default.FontSize(8);

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().AlignRight().Text(text =>
                    {
                        text.Span(resources.GetString("VehicleIdDocumentDate")).Style(footerStyle).SemiBold();
                        text.Span(": ").Style(footerStyle).SemiBold();
                        text.Span(DateTime.Now.ToString("dd/MM/yyyy")).Style(footerStyle);
                    });
                });
            });
        }

        private void ComposeColumn0(ColumnDescriptor column)
        {
            column.Spacing(10);

            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentStateIssuing"), Model.StateIssuing));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentCompetentAuthority"), Model.CompetentAuthority));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentAuthorityIssuing"), Model.AuthorityIssuing));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentUnambiguousNumber"), Model.UnambiguousNumber));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentIssuingDate"), Model.IssuingDate));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentExpiryDate"), Model.ExpiryDate));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentSerialNumber"), Model.SerialNumber));
        }

        private void ComposeColumn1(ColumnDescriptor column)
        {
            column.Spacing(10);

            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentDateOfFirstRegistration"), Model.DateOfFirstRegistration));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentYearOfProduction"), Model.YearOfProduction));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentVehicleMake"), Model.VehicleMake));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentVehicleType"), Model.VehicleType));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentCommercialDescription"), Model.CommercialDescription));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentVehicleIdNumber"), Model.VehicleIdNumber));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentRegistrationNumberOfVehicle"), Model.RegistrationNumberOfVehicle));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentMaximumNetPower"), Model.MaximumNetPower));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentEngineCapacity"), Model.EngineCapacity));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentTypeOfFuel"), Model.TypeOfFuel));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentPowerWeightRatio"), Model.PowerWeightRatio));
        }

        private void ComposeColumn2(ColumnDescriptor column)
        {
            column.Spacing(10);

            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentVehicleMass"), Model.VehicleMass));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentMaximumPermissibleLadenMass"), Model.MaximumPermissibleLadenMass));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentTypeApprovalNumber"), Model.TypeApprovalNumber));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentNumberOfSeats"), Model.NumberOfSeats));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentNumberOfStandingPlaces"), Model.NumberOfStandingPlaces));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentEngineIdNumber"), Model.EngineIdNumber));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentNumberOfAxles"), Model.NumberOfAxles));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentVehicleCategory"), Model.VehicleCategory));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentColourOfVehicle"), Model.ColourOfVehicle));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentRestrictionToChangeOwner"), Model.RestrictionToChangeOwner));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentVehicleLoad"), Model.VehicleLoad));
        }

        private void ComposeColumn3(ColumnDescriptor column)
        {
            column.Spacing(10);

            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentOwnersPersonalNo"), Model.OwnersPersonalNo));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentOwnersSurnameOrBusinessName"), Model.OwnersSurnameOrBusinessName));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentOwnerName"), Model.OwnerName));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentOwnerAddress"), Model.OwnerAddress));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentUsersPersonalNo"), Model.UsersPersonalNo));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentUsersSurnameOrBusinessName"), Model.UsersSurnameOrBusinessName));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentUsersName"), Model.UsersName));
            column.Item().Component(new FieldComponent(resources.GetString("VehicleIdDocumentUsersAddress"), Model.UsersAddress));
        }
    }
}
