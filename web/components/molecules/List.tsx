import IList from "@/interfaces/components/molecules/IList";
import Title from "@/components/atoms/Title";
import StringList from "@/components/atoms/StringList";

export default (props: IList) => {
    return (
        <div>
            <Title {...props.title}/>
            <StringList {...props.list}/>
        </div>
    );
}