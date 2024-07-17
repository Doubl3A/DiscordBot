import PageColor from "@/util/PageColor";

export default function Template({children}: { children: React.ReactNode }) {
    return (
        <>
            <PageColor/>
            {children}
        </>
    )
}