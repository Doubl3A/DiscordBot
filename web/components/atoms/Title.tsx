import ITitle from "@/interfaces/components/atoms/ITitle";
import TitleEnum from "@/values/Enum/TitleEnum";

export default (props: ITitle) => {

    let element;
    switch (props.type) {
        case TitleEnum.H1:
            element = <h1 className={"text-5xl font-bold"}>{props.title}</h1>
            break;
        case TitleEnum.H3:
            element = <h3 className={"text-2xl font-semibold"}>{props.title}</h3>
            break;
        case TitleEnum.H4:
            element = <h4 className={"text-xl font-semibold"}>{props.title}</h4>
            break;
        case TitleEnum.H5:
            element = <h5 className={"text-lg font-semibold"}>{props.title}</h5>
            break;
        case TitleEnum.H6:
            element = <h6 className={"text-lg font-medium"}>{props.title}</h6>
            break;
        case TitleEnum.H2:
        default:
            element = <h2 className={"text-3xl font-semibold"}>{props.title}</h2>
            break;
    }

    return (
        <>
            {element}
        </>
    );
}