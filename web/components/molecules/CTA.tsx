import Title from "@/components/atoms/Title";
import Button from "@/components/atoms/Button";
import ICTA from "@/interfaces/components/molecules/ICTA";

export default (props: ICTA) => {
    return (
        <section className={"flex justify-around"}>
            <Title {...props.title}/>
            <Button {...props.button}/>
        </section>
    )
}