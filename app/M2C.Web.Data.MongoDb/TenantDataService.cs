using M2C.Core.Abstractions;
using M2C.Data.Abstractions;
using M2C.Data.MongoDb;
using M2C.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Web.Data.MongoDb
{
    public class TenantDataService : MongoDbDataService<Tenant>
    {


        protected override IResponse<Tenant> Get(IParameters parameters)
        {
            var response = new DataResponse<Tenant>() { };
            response.Items = GenerateTenants();
            response.SetStatus(true);
            return response;
        }


        #region temporary stub

        private List<Tenant> GenerateTenants()
        {
            List<Tenant> list = new List<Tenant>
            {
                new Tenant()
                {
                    Id = "101"
                    ,GlobalId = Guid.NewGuid().ToString()
                    ,Title = "m2c development"
                    ,Display = "My2Cents Developer"
                    ,Status = "active"
                    ,Subdomain = "dev"
                    ,MetaTags = new List<MetaTag>(){
                    new MetaTag() {
                        Name = "copyright",
                        Content = ""
                    }
                    ,new MetaTag() {
                        Name = "description",
                        Content = "The My2Cents site is intended for developers only "
                    }
                    ,new MetaTag() {
                        Name = "keywords",
                        Content = "content management system, sdlc, software development lifecycle"
                    }
                    ,new MetaTag() {
                        Name = "robots",
                        Content = "index,follow"
                    }
                }
                ,
                    Images = new List<Image>() {
                    new Image() {  Size = "small", Usage = "banner", AltText = "dev banner logo", Theme = "dark", Url = "images/{subdomain}/logos/banner_dark_small.png" }
                    ,new Image() { Size = "medium", Usage = "banner", AltText = "dev banner logo", Theme = "dark", Url = "images/{subdomain}/logos/banner_dark_medium.png" }
                    ,new Image() { Size = "large", Usage = "banner", AltText = "dev banner logo", Theme = "dark", Url = "images/{subdomain}/logos/banner_dark_large.png" }
                    ,new Image() { Size = "small", Usage = "footer-logo", AltText = "dev footer logo", Theme = "dark", Url = "images/{subdomain}/logos/footer_dark_small.png" }
                    ,new Image() { Size = "medium", Usage = "footer-logo", AltText = "dev footer logo", Theme = "dark", Url = "images/{subdomain}/logos/footer_dark_medium.png" }
                    ,new Image() { Size = "large", Usage = "footer-logo", AltText = "dev footer logo", Theme = "dark", Url = "images/{subdomain}/logos/footer_dark_large.png" }
            }
                },
                new Tenant()
                {
                    Id = "1003"
                ,    GlobalId = Guid.NewGuid().ToString()
                ,
                    Title = "gw sol"
                ,
                    Display = "Great Wall Solutions"
                ,
                    Status = "active"
                ,
                    Subdomain = "great-wall"
                ,
                    MetaTags = new List<MetaTag>(){
                    new MetaTag() {
                        Name = "copyright",
                        Content = ""
                    }
                    ,new MetaTag() {
                        Name = "description",
                        Content = "The Great Wall site is intended for developers only "
                    }
                    ,new MetaTag() {
                        Name = "keywords",
                        Content = "content management system, sdlc, software development lifecycle"
                    }
                    ,new MetaTag() {
                        Name = "robots",
                        Content = "index,follow"
                    }
                }
                ,
                    Images = new List<Image>() {
                    new Image() {  Size = "small", Usage = "banner", AltText = "dev banner logo", Theme = "dark", Url = "images/{subdomain}/logos/banner_dark_small.png" }
                    ,new Image() { Size = "medium", Usage = "banner", AltText = "dev banner logo", Theme = "dark", Url = "images/{subdomain}/logos/banner_dark_medium.png" }
                    ,new Image() { Size = "large", Usage = "banner", AltText = "dev banner logo", Theme = "dark", Url = "images/{subdomain}/logos/banner_dark_large.png" }
                    ,new Image() { Size = "small", Usage = "footer-logo", AltText = "dev footer logo", Theme = "dark", Url = "images/{subdomain}/logos/footer_dark_small.png" }
                    ,new Image() { Size = "medium", Usage = "footer-logo", AltText = "dev footer logo", Theme = "dark", Url = "images/{subdomain}/logos/footer_dark_medium.png" }
                    ,new Image() { Size = "large", Usage = "footer-logo", AltText = "dev footer logo", Theme = "dark", Url = "images/{subdomain}/logos/footer_dark_large.png" }
            }
                },
                new Tenant()
                {
                    Id = "1005"
                ,
                    GlobalId = Guid.NewGuid().ToString()
                ,
                    Title = "cyclops"
                ,
                    Display = "Cyclops"
                ,
                    Status = "active"
                ,
                    Subdomain = "cyclops"
                ,
                    MetaTags = new List<MetaTag>(){
                    new MetaTag() {
                        Name = "copyright",
                        Content = ""
                    }
                    ,new MetaTag() {
                        Name = "description",
                        Content = "The Cyclops site is intended for developers only "
                    }
                    ,new MetaTag() {
                        Name = "keywords",
                        Content = "content management system, sdlc, software development lifecycle"
                    }
                    ,new MetaTag() {
                        Name = "robots",
                        Content = "index,follow"
                    }
                }
                ,
                    Images = new List<Image>() {
                    new Image() {  Size = "small", Usage = "banner", AltText = "dev banner logo", Theme = "dark", Url = "images/{subdomain}/logos/banner_dark_small.png" }
                    ,new Image() { Size = "medium", Usage = "banner", AltText = "dev banner logo", Theme = "dark", Url = "images/{subdomain}/logos/banner_dark_medium.png" }
                    ,new Image() { Size = "large", Usage = "banner", AltText = "dev banner logo", Theme = "dark", Url = "images/{subdomain}/logos/banner_dark_large.png" }
                    ,new Image() { Size = "small", Usage = "footer-logo", AltText = "dev footer logo", Theme = "dark", Url = "images/{subdomain}/logos/footer_dark_small.png" }
                    ,new Image() { Size = "medium", Usage = "footer-logo", AltText = "dev footer logo", Theme = "dark", Url = "images/{subdomain}/logos/footer_dark_medium.png" }
                    ,new Image() { Size = "large", Usage = "footer-logo", AltText = "dev footer logo", Theme = "dark", Url = "images/{subdomain}/logos/footer_dark_large.png" }
            }
                }
            };
            return list;
        }

        #endregion
    }
}
