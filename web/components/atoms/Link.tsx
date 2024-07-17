import ILink from "@/interfaces/components/atoms/ILink";
import Link from "next/link";

export default (props: ILink) => {
    return (
        <Link className={"text-base font-semibold underline " + props.className} href={props.url}>
            {props.text}
        </Link>
    )
}