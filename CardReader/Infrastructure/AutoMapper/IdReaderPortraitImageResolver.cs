using System.IO;
using AutoMapper;
using CardReader.Core.Model.IdReader;
using Microsoft.UI.Xaml.Media.Imaging;

namespace CardReader.Infrastructure.AutoMapper
{
    internal class IdReaderPortraitImageResolver : IValueResolver<IdReaderData, object, BitmapImage>
    {
        public BitmapImage Resolve(IdReaderData source, object destination, BitmapImage destMember, ResolutionContext context)
        {
            if (source?.Portrait == null) return null;
            var image = new BitmapImage();
            using var stream = new MemoryStream();
            stream.Write(source.Portrait);
            stream.Seek(0, SeekOrigin.Begin);
            image.SetSource(stream.AsRandomAccessStream());
            return image;
        }
    }
}
