import type {Metadata} from "next";
import {Noto_Sans} from "next/font/google";
import {SpeedInsights} from '@vercel/speed-insights/next';
import {Analytics} from "@vercel/analytics/next";
import "./globals.css";
import Footer from "@/components/organisms/Footer";
import {sharedFooter} from "@/values/text-content";
import Header from "@/components/organisms/Header";
import Template from "@/app/template";

const notoSans = Noto_Sans({subsets: ["latin"]});

export const metadata: Metadata = {
    title: "Triple A - A unique Discord bot",

};

export default function RootLayout({children}: Readonly<{ children: React.ReactNode; }>) {
    return (
        <html lang="en">
        <body className={notoSans.className + " content-grid gap-y-16 min-h-screen"}>
        <Header/>
        <main id="main-content" className="content-grid gap-y-16">
            <Template>
                {children}
            </Template>
        </main>
        <Footer {...sharedFooter}/>
        <SpeedInsights/>
        <Analytics/>
        </body>
        </html>
    );
}