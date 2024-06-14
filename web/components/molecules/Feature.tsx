import IFeature from "@/interfaces/components/molecules/IFeature";
import Paragraph from "@/components/atoms/Paragraph";
import Title from "@/components/atoms/Title";
import Icon from "@/components/atoms/Icon";
import List from "@/components/molecules/List";
import Separator from "@/components/atoms/Separator";

export default (props: IFeature) => {
    return (
        <li className={"list-none grid gap-6"}>
            <div className={"grid gap-4"}>
                <Title {...props.title}/>
                <div className={"flex gap-6"}>
                    <div className={"grid gap-4"}>
                        <Paragraph {...props.intro}/>
                        <List {...props.featureList}/>
                        <Paragraph {...props.text}/>
                    </div>
                    <div className={"w-40 h-40"}>
                        <Icon {...props.icon}/>
                    </div>
                </div>
            </div>
            <Separator/>
        </li>
    )
}