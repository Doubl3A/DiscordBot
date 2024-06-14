"use client"
import Color from "@/values/Enum/Color";
import {useEffect} from "react";

/**
 * Set the page background color
 * @constructor
 */
export default () => {

    useEffect(() => {
        let color: Color;
        switch (window.location.pathname) {
            case "/":
                color = Color.Blurple;
                break;
            case "/terms-of-use":
                color = Color.Green
                break;
            default:
                color = Color.Red
        }

        const colorVar = `--color-${Color[color].toLowerCase()}`;
        document.documentElement.style.setProperty("--current-background", `var(${colorVar})`);
    }, [])
    return (
        <></>
    )
}

interface IPageColor {
    color: Color;
}