using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using CardReader.Model;
using Microsoft.UI.Xaml.Media.Imaging;

namespace CardReader.AutoMapper
{
    public class IdReaderPortraitImageResolver : IValueResolver<IdReaderData, object, BitmapImage>
    {
        public BitmapImage Resolve(IdReaderData source, object destination, BitmapImage destMember, ResolutionContext context)
        {
            if (source.Portrait == null) return null;
            var image = new BitmapImage();
            using var stream = new MemoryStream();
            stream.Write(source.Portrait);
            stream.Seek(0, SeekOrigin.Begin);
            image.SetSource(stream.AsRandomAccessStream());
            return image;
        }
    }
}
