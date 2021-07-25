import { Company } from "./company";
import { DatesEmployed } from "./dates-employed";
import { Organization } from "./organization";
import { Senority } from "./senority";
import { Stack } from "./stack";

export type Position = {
    positionId?: string,
    title?: string,
    companyId?: string,
    company?: Company,
    datesEmployed?: DatesEmployed
    isCurrent?: boolean,
    stack?: Stack,
    senority?: Senority,
    description?: string,
    organization?: Organization
};

