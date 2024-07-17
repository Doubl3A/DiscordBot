import ISlogan from "@/interfaces/components/molecules/ISlogan";
import Title from "../atoms/Title";
import TitleEnum from "@/values/Enum/TitleEnum";

export default (props: ISlogan) => {
    return (
        <>
            <Title title={props.text} type={TitleEnum.H5}/>
        </>
    )
}