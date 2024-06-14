"use client"

import IButton from "@/interfaces/components/atoms/IButton";

export default (props: IButton) => {
    return (
        <button onClick={props.onClick}
                className={"bg-blurple rounded-md px-4 py-2 h-min hover:bg-opacity-50" + props.className}>
            {props.text}
        </button>
    )
}