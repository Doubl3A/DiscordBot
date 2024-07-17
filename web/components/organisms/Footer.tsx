import IFooter from "@/interfaces/components/organisms/IFooter";
import Link from "@/components/atoms/Link";

export default (props: IFooter) => {
    return (
        <footer className={"w-full flex justify-center h-[100px]"}>
            <Link {...props.link}/>
        </footer>
    );
}