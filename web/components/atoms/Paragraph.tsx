import IParagraph from "@/interfaces/components/atoms/IParagraph";

export default (props: IParagraph) => {
    return (
        <p className={"text-base " + props.className}>
            {props.text}
        </p>
    );
}