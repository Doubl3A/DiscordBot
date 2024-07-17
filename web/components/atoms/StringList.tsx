import IStringList from "@/interfaces/components/atoms/IStringList";

export default (props: IStringList) => {
    return (
        <ul className={"list-disc list-outside grid gap-y-2"}>
            {props.listElements.map(element =>
                <li className={"ml-4"}>{element}</li>
            )}
        </ul>
    )
}