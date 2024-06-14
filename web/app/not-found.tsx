import textContent from "@/values/text-content";
import ErrorBanner from "@/components/organisms/ErrorBanner";

export default function NotFound() {
    const content = textContent.errorPage;
    
    return (
        <div className={"h-full"}>
            <ErrorBanner {...content.banner}/>
        </div>
    );
}