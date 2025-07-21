import patient from "./pacient.type";

export default interface ApiResponse {
    isSuccess: boolean;
    data: patient[];
    code: string | null;
    message: string;
    errors: any | null;
    errorCode: string | null;
    errorMessage: string | null;
  }