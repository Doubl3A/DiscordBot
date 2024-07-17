import IFeatureList from "@/interfaces/components/organisms/IFeatureList";
import Title from "@/components/atoms/Title";
import IFeature from "@/interfaces/components/molecules/IFeature";
import Feature from "@/components/molecules/Feature";
import Separator from "@/components/atoms/Separator";

export default (props: IFeatureList) => {
    return (
        <section className={"grid gap-6"}>
            <div className={"grid gap-6"}>
                <Title {...props.title} className={""}/>
                <Separator/>
            </div>
            <ul className={"grid gap-6"}>
                {props.featureList.map((feature: IFeature) =>
                    <Feature {...feature}/>
                )}
            </ul>
        </section>
    );
}