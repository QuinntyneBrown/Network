import { Company } from "./company";

export type Organization = {
    organizationId: string,
    name: string,
    logoDigitalAssetId: string,
    companies: Company[]
};
