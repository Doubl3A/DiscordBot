import PageColor from "@/util/PageColor";

export default function Template({children}: { children: React.ReactNode }) {
    return (
        <div className={"grid gap-16"}>
            <PageColor/>
            {children}
        </div>
    )
}