import ISharedProperties from "../shared/ISharedProperties";

export default interface IButton extends ISharedProperties {
    text: string,
    onClick?: () => void,
}