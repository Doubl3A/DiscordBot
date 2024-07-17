import TitleEnum from "@/values/Enum/TitleEnum";
import ISharedProperties from "@/interfaces/components/shared/ISharedProperties";

export default interface ITitle extends ISharedProperties {
    title: string,
    type: TitleEnum;
}