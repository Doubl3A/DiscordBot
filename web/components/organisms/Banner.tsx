import IBanner from "@/interfaces/components/organisms/IBanner";
import Title from "@/components/atoms/Title";
import TitleEnum from "@/values/Enum/TitleEnum";
import Paragraph from "@/components/atoms/Paragraph";
import Icon from "@/components/atoms/Icon";
import Slogan from "@/components/molecules/Slogan";

export default (props: IBanner) => {
    return (
        <section className={"flex items-center justify-between"}>
            <div className={"grid gap-2.5 max-w-[650px]"}>
                <Title title={props.title} type={TitleEnum.H1}/>
                <Slogan text={props.slogan}/>
                <Paragraph text={props.intro}/>
            </div>
            <div className={"h-32 w-32"}>
                <Icon {...props.icon}/>
            </div>
        </section>
    )
}