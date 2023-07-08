import * as yup from "yup";
import { AuthenticateCommand } from "~/app/ApiClient";


export const initialLoginFormData: AuthenticateCommand = {
    email: "",
    password: "",
  };  
  export const loginFormSchema = yup.object().shape({
    email: yup.string().required("Email is required").email(),
    password: yup.string().required("Password is requried"),
  });
