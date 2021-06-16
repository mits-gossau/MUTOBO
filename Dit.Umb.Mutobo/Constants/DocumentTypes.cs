namespace Dit.Umb.Mutobo.Constants
{
    public static class DocumentTypes
    {
        public static class Accordeon
        {
            public const string Alias = "accordeon";
            public static class Fields
            {
                public const string Summary = "summary";
                public const string Details = "details";
            }
        }
        public static class DoubleSliderComponent
        {

            public const string Alias = "doubleSlider";

            public static class Fields
            {
                public const string Slides = "slides";
                public const string Height = "height";
                public const string Width = "width";
                public const string Interval = "interval";
                public const string DisplayType = "displayType";

            }
        }
        public static class TextImageSlide
        {
            public const string Alias = "textImageSlide";

            public static class Fields
            {
                public const string Link = "link";
                public const string Image = "image";
                public const string Text = "text";
                public const string Title = "title";
            }

        }

        public static class BasePage
        {
            public static string Alias = "basePage";


            public static class Fields
            { 
                // BasePage
                public const string PageTitle = "pageTitle";
                public const string HideFromNavigation = "hideFromNavigation";
                public const string NotClickable = "notClickable";
                public const string RedirectLink = "redirectLink";
                public const string OpenInNewWindow = "newWindow";
                // SEO Data
                public const string MetaTitle = "metaTitle";
                public const string MetaDescription = "metaDescription";
                public const string MetaKeywords = "metaKeywords";
                public const string ExcludeFromXMLSitemap = "excludeFromXMLSitemap";
                public const string SearchEngineFrequency = "searchEngineFrequency";
                public const string SearchEngineRelativePriority = "searchEngineRelativePriority";
                public const string Theme = "theme";
                public const string HeaderConfiguration = "headerConfiguration";
                public const string FooterConfiguration = "footerConfiguration";
                public const string GoogleAnalyticsKey = "googleAnalyticsKey";
                public const string Thumbnail = "thumbnail";
                public const string ExcludeFromSearch = "excludeFromSearch";

            }
        }


        public static class SearchResults
        {
            public static string Alias = "searchResults";


            public static class Fields
            {
                // BasePage
                public const string PageTitle = "pageTitle";



            }
        }



        public static class HomePage
        {
            public static string Alias = "homePage";

            public static class Fields
            {
                public static string Disturber = "disturber";
                public static string SloganTitle = "sloganTitle";
                public static string SloganSubTitle = "sloganSubTitle";
                public static string Modules = "modules";


            }
        }
        public static class ArticlePage
        {
            public static string Alias = "articlePage";

            public static class Fields
            {
                public const string Abstract = "abstract";
                public const string HideAbstract = "hideAbstract";
                public const string MainContent = "mainContent";
                public const string EmotionImages = "emotionImages";
                public const string TeaserImageHeight = "teaserImageHeight";
                public const string TeaserImageWidth = "teaserImageWidth";
            }
        }


        public static class TeaserPage
        {
            public static string Alias = "teaserPage";

            public static class Fields
            {
                public const string Teasers = "teasers";

            } 
        }



        public static class Theme {
            public static string Alias = "theme";

            public static class Fields
            {
                public const string BackgroundColor = "backgroundColor";
                public const string ColorHover = "colorHover";
                public const string ColorSecondary = "colorSecondary";
                public const string Color = "color";
                public const string FontFamily = "fontFamily";
                public const string FooterBackgroundColor = "footerBackgroundColor";
                public const string HeaderBackgroundColor = "headerBackgroundColor";
                public const string FooterColorHover = "footerColorHover";
                public const string FooterColor = "footerColor";
                public const string HeaderColor = "headerColor";
                public const string NavigationBackgroundColor = "navigationBackgroundColor";
                public const string NavigationColorHover = "navigationColorHover";
                public const string NavigationColor = "navigationColor";
                public const string NavigationHrColor = "navigationHrColor";
                public const string HrColor = "hrColor";
                public const string PageTheme = "pageTheme";

            }
        }


        public static class ImpressumPage
        {
            public static string Alias = "impressumPage";

            public static class Fields
            {
                public const string HtmlContent = "htmlContent";

            }
        }


        public static class Configuration
        {
            public const string Logo = "logo";
            public const string Link = "logoUrl";
        }

        public static class Link
        {
            public const string ExternalLink = "externalLinkUrl";
            public const string InternalLink = "internalLinkUrl";
            public const string OpenNewWindow = "openNewWindow";
            public const string Text = "linkTitle";
        }

        public static class FooterConfiguration
        {
            public const string Alias = "footerConfiguration";

            public static class Fields
            {

                public const string NavigationArea = "navigationArea";
                public const string ContactArea = "contactArea";
                public const string Links = "footerLinks";
                public const string BlockLinks = "blockLinks";
                public const string PictureLinks = "pictureLinks";
                public const string CopyRight = "copyRight";
            }

        }

        public static class FooterNavBlock
        {
            public const string StartNode = "startNode";
        }

        public static class FooterContact
        {
            public const string Headline = "headline";
            public const string AddressBlock = "addressBlock";
        }

        public static class Flyer
        {
            public const string Alias = "flyer";

            public static class Fields
            {
                public const string Link = "link";
                public const string Color = "color";
                public const string Direction = "direction";
                public const string Width = "width";
                public const string Height = "height";
                public const string Rotation = "rotation";
                public const string Timer = "timer";
                public const string Position = "position";
                public const string FlyerTitle = "flyerTitle";
                public const string FlyerImage = "flyerImage";
                public const string FlyerTeaserText = "flyerTeaserText";
                public const string FlyerLink = "website";
                public const string MarginTop = "marginTop";
                public const string MarginSide = "marginSide";
                public const string TextHeight = "textHeight";
                public const string TextWidth = "textWidth";
            }


        }


        public static class PictureLink
        {
            public const string Alias = "pictureLink";

            public static class Fields
            {
                public const string Image = "image";
                public const string Link = "link";
                public const string LogoLink = "logoLink";
                public const string Text = "text";
                public const string MaxHeight = "maxHeight";
                public const string PaddingTop = "paddingTop";
                public const string PaddingRight = "paddingRight";
                public const string PaddingBottom = "paddingBottom";
                public const string PaddingLeft = "paddingLeft";
            }                       
        }

        public static class FormPage
        {
            public const string Alias = "formPage";

            public static class Fields
            {
                public const string LabelName = "labelName";
                public const string LabelFirstName = "labelFirstname";
                public const string LabelAddress = "labelAddress";
                public const string LabelZipCity = "labelZipCity";
                public const string LabelMail = "labelMail";
                public const string LabelPhone = "labelPhone";
                public const string LabelMessage = "labelMessage";
                public const string MailConfigurationCustomer = "mailConfigurationCustomer";
                public const string MailConfigurationReceiver = "mailConfigurationReceiver";
                public const string SuccessPage = "successPage";
            }
        }

        public static class MailConfiguration
        {
            public const string Alias = "mailConfiguration";

            public static class Fields
            {
                public const string MailSubject = "mailSubject";
                public const string MailBody = "mailBody";
                public const string MailHeader = "mailHeader";
                public const string MailFooter = "mailFooter";
                public const string SenderMail = "senderMail";
                public const string ReceiverMail = "receiverMail";
            }
        }


        public static class VideoComponent
        {
            public const string Alias = "videoComponent";

            public static class Fields
            {
                public const string VideoFile = "videoFile";
                public const string Embedded = "embedded";
                public const string Text = "text";
                public const string Height = "height";
                public const string Width = "width";
            }
        }

        public static class RichTextComponent
        {
            public const string Alias = "richTextComponent";

            public static class Fields
            {
                public const string RichText = "richText";
       
            }
        }


        public static class Heading
        {
            public const string Alias = "heading";

            public static class Fields
            {
                public const string Text = "text";
                public const string RenderAs = "renderAs";
                public const string NavigationAnchor = "navigationAnchor";
            }
        }


        public static class Teaser
        {
            public const string Alias = "teaser";

            public static class Fields
            {
                public const string Link = "link";
                public const string Images = "images";
                public const string UseArticleData = "useArticleData";
                public const string TeaserTitle = "teaserTitle";
                public const string TeaserText = "teaserText";
                public const string RenderAs = "renderAs";

            }

        }

        public static class ContentPage
        {
            public const string Alias = "contentPage";

            public static class Fields
            {
                public const string Modules = "modules";
            }
        }





        public static class SliderComponent
        {
            public const string Alias = "sliderComponent";

            public static class Fields
            {
                public const string Slides = "slides";
                public const string Height = "height";
                public const string Width = "width";
                public const string Interval = "interval";
                public const string DisplayType = "displayType";
            }
        }


        public static class Picture
        {
            public const string Alias = "picture";

            public static class Fields
            {
                public const string Image = "image";
            }
        }


        public static class PictureModule
        {
            public const string Alias = "pictureModule";

            public static class Fields
            {
                public const string Image = "image";
                public const string Height = "height";
                public const string Width = "width";
            }
        }

        public static class Interpretors
        {
            public static class Conductor
            {
                public const string Alias = "conductor";
            }
            public static class Composer
            {
                public const string Alias = "composer";
            }
            public static class Orchestra
            {
                public const string Alias = "orchestra";
            }
            public static class Soloist
            {
                public const string Alias = "soloist";
            }
        }

        public static class Newsletter
        {
            public const string Alias = "newsletter";

            public static class Fields
            {
                public const string Information = "information";
                public const string Frequency = "frequency";
                public const string MessageSuccess = "messagesuccess";
                public const string MessageError = "messageerror";
                
            }
        }

        public static class BlogModule
        {
            public const string Alias = "blogModule";
            public static class Fields
            {
                public const string ParentPage = "parentPage";
            }

        }

        public static class Quote
        {
            public const string Alias = "quote";

            public static class Fields
            {
                public const string QuoteText = "quoteText";
                public const string SpellerName = "spellerName";
                public const string SpellerFunction = "spellerFunction";
            }
        }

        public static class CardContainer
        {
            public const string Alias = "cardContainer";

            public static class Fields
            {
                public const string Cards = "cards";
            }
        }

        public static class Card
        {
            public const string Alias = "card";

            public static class Fields
            {
                public const string DetailPageLink = "detailPageLink";
                public const string Image = "image";
            }
        }

        public static class PersonnelCard
        {
            public const string Alias = "personnelCard";

            public static class Fields
            {

                public const string Lastname = "lastname";
                public const string Firstname = "firstname";
                public const string Function = "function";
            }
        }


    }
}
