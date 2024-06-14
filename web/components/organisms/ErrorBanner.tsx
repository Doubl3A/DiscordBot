import IErrorBanner from "@/interfaces/components/organisms/IErrorBanner";
import Icon from "@/components/atoms/Icon";
import Title from "@/components/atoms/Title";
import Link from "@/components/atoms/Link";

export default (props: IErrorBanner) => {
    return (
        <section className={"flex gap-8 items-center"}>
            <div className={"grid gap-6"}>
                <Title {...props.title}/>
                <Link {...props.link}/>
            </div>
            <div className={"w-80"}>
                <Icon {...props.icon}/>
            </div>
        </section>
    )
}