import IFooter from "@/interfaces/components/organisms/IFooter";
import Link from "@/components/atoms/Link";

export default (props: IFooter) => {
    return (
        <section className={"w-full flex justify-center h-[100px]"}>
            <Link {...props.link}/>
        </section>
    );
}