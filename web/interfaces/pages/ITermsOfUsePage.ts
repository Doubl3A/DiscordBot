import ITitle from "@/interfaces/components/atoms/ITitle";
import IParagraph from "@/interfaces/components/atoms/IParagraph";
import ITermsList from "@/interfaces/components/organisms/ITermsList";

export default interface ITermsOfUsePage {
    title: ITitle,
    intro: IParagraph,
    termsOfUse: ITermsList[],
}