using CardReader.Core.Model.IdReader;
using CardReader.Core.Service.IdReader;
using CardReader.Core.Service.Resources;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace CardReader.Reports.IdReader
{
    internal class IdReaderDocument : IDocument
    {
        private IdReaderData Model { get; }

        private readonly IApplicationResources resources;

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public IdReaderDocument(IdReaderData model, IApplicationResources resources)
        {
            Model = model;
            this.resources = resources;
        }

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
                    column.Item().Height(50).AlignCenter().Text(resources.GetString("IdDocumentTitle")).Style(titleStyle);
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
                row.ConstantItem(180).Column(ComposeColumn3);
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
                        text.Span(resources.GetString("IdDocumentDate")).Style(footerStyle).SemiBold();
                        text.Span(": ").Style(footerStyle).SemiBold();
                        text.Span(DateTime.Now.ToString("dd/MM/yyyy")).Style(footerStyle);
                    });
                });
            });
        }

        private void ComposeColumn0(ColumnDescriptor column)
        {
            column.Spacing(10);

            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentCardType"), GetCardType(Model.CardType)));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentDocRegNo"), Model.DocRegNo));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentDocumentType"), Model.DocumentType));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentIssuingDate"), Model.IssuingDate));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentExpiryDate"), Model.ExpiryDate));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentIssuingAuthority"), Model.IssuingAuthority));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentDocumentSerialNumber"), Model.DocumentSerialNumber));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentChipSerialNumber"), Model.ChipSerialNumber));
        }

        private void ComposeColumn1(ColumnDescriptor column)
        {
            column.Spacing(10);

            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentPersonalNumber"), Model.PersonalNumber));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentSurname"), Model.Surname));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentGivenName"), Model.GivenName));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentParentGivenName"), Model.ParentGivenName));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentSex"), Model.Sex));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentPlaceOfBirth"), Model.PlaceOfBirth));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentStateOfBirth"), Model.StateOfBirth));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentDateOfBirth"), Model.DateOfBirth));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentCommunityOfBirth"), Model.CommunityOfBirth));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentStatusOfForeigner"), Model.StatusOfForeigner));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentNationalityFull"), Model.NationalityFull));
        }

        private void ComposeColumn2(ColumnDescriptor column)
        {
            column.Spacing(10);

            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentState"), Model.State));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentCommunity"), Model.Community));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentPlace"), Model.Place));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentStreet"), Model.Street));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentHouseNumber"), Model.HouseNumber));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentHouseLetter"), Model.HouseLetter));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentEntrance"), Model.Entrance));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentFloor"), Model.Floor));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentApartmentNumber"), Model.ApartmentNumber));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentAddressDate"), Model.AddressDate));
            column.Item().Component(new FieldComponent(resources.GetString("IdDocumentAddressLabel"), Model.AddressLabel));
        }

        private void ComposeColumn3(ColumnDescriptor column)
        {
            var portrait = Model.Portrait ?? GetAvatarImage();
            column.Item().Image(portrait);
        }

        private string GetCardType(int cardType)
        {
            return cardType switch
            {
                IIdReaderService.EID_CARD_ID2008 => resources.GetString("IdReaderCardTypeOld"),
                IIdReaderService.EID_CARD_ID2014 => resources.GetString("IdReaderCardTypeNew"),
                IIdReaderService.EID_CARD_IF2020 => resources.GetString("IdReaderCardTypeForeigner"),
                _ => resources.GetString("IdReaderCardTypeUnknown"),
            };
        }

        private static byte[] GetAvatarImage()
        {
            var task = Task.Run(async () =>
            {
                var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/avatar.jpg"));
                using var stream = await storageFile.OpenReadAsync();
                using var dr = new DataReader(stream.GetInputStreamAt(0));
                var bytes = new byte[stream.Size];
                await dr.LoadAsync((uint)stream.Size);
                dr.ReadBytes(bytes);
                return bytes;
            });
            return task.Result;
        }
    }
}
