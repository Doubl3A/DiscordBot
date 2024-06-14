import ISharedProperties from "@/interfaces/components/shared/ISharedProperties";

export default interface ILink extends ISharedProperties {
    text: string;
    url: string;
}