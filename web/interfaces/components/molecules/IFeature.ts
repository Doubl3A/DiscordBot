import IParagraph from "@/interfaces/components/atoms/IParagraph";
import IList from "@/interfaces/components/molecules/IList";
import ITitle from "@/interfaces/components/atoms/ITitle";
import IIcon from "@/interfaces/components/atoms/IIcon";

export default interface IFeature {
    title: ITitle;
    intro: IParagraph,
    featureList: IList,
    text: IParagraph,
    icon: IIcon
}