import IStringList from "@/interfaces/components/atoms/IStringList";

export default (props: IStringList) => {
    return (
        <ul className={"grid gap-1 list-disc list-outside"}>
            {props.listElements.map(element =>
                <li className={"ml-4"}>{element}</li>
            )}
        </ul>
    )
}