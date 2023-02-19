using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CardReader.Transformer
{
    public abstract class Transformer<T, TU>
    {
        protected readonly IMapper mapper;

        public Transformer() : this(App.Current.Services.GetService<IMapper>())
        {
        }

        public Transformer(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TU Transform(T src)
        {
            return TransformInternal(src);
        }

        public T TransformBack(TU src)
        {
            return TransformBackInternal(src);
        }

        public IEnumerable<TU> Transform(IEnumerable<T> src)
        {
            return TransformInternal(src);
        }

        public IEnumerable<T> TransformBack(IEnumerable<TU> src)
        {
            return TransformBackInternal(src);
        }

        protected virtual TU TransformInternal(T src)
        {
            return mapper.Map<TU>(src);
        }

        protected virtual T TransformBackInternal(TU src)
        {
            return mapper.Map<T>(src);
        }

        protected virtual IEnumerable<TU> TransformInternal(IEnumerable<T> src)
        {
            return mapper.Map<IEnumerable<TU>>(src);
        }

        protected virtual IEnumerable<T> TransformBackInternal(IEnumerable<TU> src)
        {
            return mapper.Map<IEnumerable<T>>(src);
        }
    }
}
