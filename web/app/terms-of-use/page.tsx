import textContent from "@/values/text-content";
import Title from "@/components/atoms/Title";
import Paragraph from "@/components/atoms/Paragraph";
import TermsList from "@/components/organisms/TermsList";
import ITermsList from "@/interfaces/components/organisms/ITermsList";

export default () => {
    const content = textContent.termsOfUsePage;

    //PageColor(Color.Green)

    return (
        <section className={"grid gap-4"}>
            <Title className={""} {...content.title}/>
            <Paragraph {...content.intro}/>
            <ul className={"list-decimal list-inside grid gap-y-8"}>
                {content.termsOfUse.map((terms: ITermsList) => <TermsList {...terms}/>)}
            </ul>
        </section>
    )
}