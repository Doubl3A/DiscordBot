"use client"

export default function Button() {
    const ChangeBackgroundColor = () => {
        const backgroundList = [
            "--color-red",
            "--color-fushcia",
            "--color-yellow",
            "--color-green",
            "--color-blurple"
        ]

        const randomColor = backgroundList[Math.floor(Math.random() * backgroundList.length)];

        document.documentElement.style.setProperty("--current-background", `var(${randomColor})`);
    }

    return (
        <button onClick={ChangeBackgroundColor}
                className={"bg-blurple rounded-md px-4 py-2 h-min hover:bg-opacity-50"}>
            Click Me!
        </button>
    )
}