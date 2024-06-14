import IHomePage from "@/interfaces/pages/IHomePage";
import IErrorPage from "@/interfaces/pages/IErrorPage";
import ITermsOfUsePage from "@/interfaces/pages/ITermsOfUsePage";

export default interface ISite {
    homePage: IHomePage,
    errorPage: IErrorPage,
    termsOfUsePage: ITermsOfUsePage,
}