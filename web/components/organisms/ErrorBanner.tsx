import IErrorBanner from "@/interfaces/components/organisms/IErrorBanner";
import Icon from "@/components/atoms/Icon";
import Title from "@/components/atoms/Title";
import Link from "@/components/atoms/Link";

export default (props: IErrorBanner) => {
    return (
        <section className={"flex gap-8 items-center max-md:flex-col"}>
            <div className={"grid gap-6"}>
                <Title {...props.title}/>
                <Link {...props.link}/>
            </div>
            <div className={"w-80 max-md:w-full max-md:grid max-md:justify-center"}>
                <Icon {...props.icon}/>
            </div>
        </section>
    )
}