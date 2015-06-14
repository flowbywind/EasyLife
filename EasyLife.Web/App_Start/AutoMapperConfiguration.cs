using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PagedList;

namespace EasyLife.Web
{
    public class AutoMapperConfiguration<Item, ItemListViewModel> 
    {
        public static void Configure()
        {
            ConfigureItemMapping();
        }

        public class PagedListConverter: ITypeConverter<PagedList<Item>, PagedList<ItemListViewModel>>
        {
            public PagedList<ItemListViewModel> Convert(ResolutionContext context)
            {
                var model = (PagedList<Item>)context.SourceValue;
                var vm = model.Select(m => Mapper.Map<Item, ItemListViewModel>(m)).ToPagedList(model.PageNumber, model.PageSize);

                return new PagedList<ItemListViewModel>(vm, model.PageNumber, model.PageSize);
            }
        }

        private static void ConfigureItemMapping()
        {
            Mapper.CreateMap<ItemListViewModel, Item>();
            Mapper.CreateMap<PagedList<Item>, PagedList<ItemListViewModel>>()
                .ConvertUsing<PagedListConverter>();
        }
    }
}