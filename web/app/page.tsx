import textContent from "@/values/text-content";
import Banner from "@/components/organisms/Banner";
import CTA from "@/components/molecules/CTA";
import FeatureList from "@/components/organisms/FeatureList";

export default function Home() {
    const content = textContent.homePage;

    return (
        <>
            <Banner {...content.banner}/>
            <CTA {...content.cta}/>
            <FeatureList {...content.featureList}/>
        </>
    );
}
