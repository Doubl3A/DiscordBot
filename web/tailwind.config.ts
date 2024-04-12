import type {Config} from "tailwindcss";

const config: Config = {
    content: [
        "./pages/**/*.{js,ts,jsx,tsx,mdx}",
        "./components/**/*.{js,ts,jsx,tsx,mdx}",
        "./app/**/*.{js,ts,jsx,tsx,mdx}",
    ],
    theme: {
        colors: {
            white: "var(--color-white)",
            black: "var(--color-black)",
            background: "var(--color-background)",
            red: "var(--color-red)",
            fushcia: "var(--color-fushcia)",
            yellow: "var(--color-yellow)",
            green: "var(--color-green)",
            blurple: "var(--color-blurple)",
        },
        extend: {
            backgroundImage: {
                "gradient-radial": "radial-gradient(var(--tw-gradient-stops))",
                "gradient-conic":
                    "conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))",
            },

        },
    },
    plugins: [],
};
export default config;
