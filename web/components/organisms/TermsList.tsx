import ITermsList from "@/interfaces/components/organisms/ITermsList";
import Title from "@/components/atoms/Title";
import StringList from "@/components/atoms/StringList";

export default (props: ITermsList) => {
    return (
        <li className={"grid gap-2"}>
            <Title {...props.title}/>
            <StringList {...props.termsList}/>
        </li>
    )
}