"use client"
import Color from "@/values/Enum/Color";
import {useEffect} from "react";

/**
 * Set the page background color
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
            case "/funding":
                color = Color.Yellow
                break;
            case "/stats":
                color = Color.Fushcia
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