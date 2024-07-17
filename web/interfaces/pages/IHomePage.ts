import IBanner from "@/interfaces/components/organisms/IBanner";
import ICTA from "@/interfaces/components/molecules/ICTA";
import IFeatureList from "@/interfaces/components/organisms/IFeatureList";

export default interface IHomePage {
    banner: IBanner,
    cta: ICTA,
    featureList: IFeatureList,
}