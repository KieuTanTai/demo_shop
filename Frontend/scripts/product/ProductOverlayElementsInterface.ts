export interface ProductOverlayElements {
    productOverlay: HTMLElement;
    productPopup: HTMLElement;
    productCards: NodeListOf<HTMLElement>;
    productCloseButton: HTMLButtonElement | null;
    productForm: HTMLFormElement;
    detailImage: HTMLImageElement;
    detailName: HTMLElement;
    detailPrice: HTMLElement;
    detailSalePrice: HTMLElement;
    detailDiscount: HTMLElement;
    detailDescription: HTMLElement;
    detailAddButton: HTMLButtonElement;
    detailBuyButton: HTMLButtonElement | null;
}
