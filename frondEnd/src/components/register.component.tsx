import { Component } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
import * as Yup from "yup";

import AuthService from "../services/auth.service";

type Props = {};

type State = {
  userName: string,
  email: string,
  password: string,
  // image: File | null,
  image: string,
  successful: boolean,
  message: string
};

export default class Register extends Component<Props, State> {
  constructor(props: Props) {
    super(props);
    this.handleRegister = this.handleRegister.bind(this);

    this.state = {
      userName: "",
      email: "",
      password: "",
      image: "",
      successful: false,
      message: ""
    };
  }

  validationSchema() {
    return Yup.object().shape({
      userName: Yup.string()
        .test(
          "len",
          "The username must be between 3 and 20 characters.",
          (val: any) =>
            val &&
            val.toString().length >= 3 &&
            val.toString().length <= 20
        )
        .required("This field is required!"),
      email: Yup.string()
        .email("This is not a valid email.")
        .required("This field is required!"),
      password: Yup.string()
        .test(
          "len",
          "The password must be between 6 and 40 characters.",
          (val: any) =>
            val &&
            val.toString().length >= 6 &&
            val.toString().length <= 40
        )
        .required("This field is required!")
      // image: Yup.mixed()
      // .required("This field is required!")
      // .test(
      //   "fileSize",
      //   "File size is too large (max 1MB)",
      //   (value) => !value || (value && value.size <= 1024 * 1024)
      // )
      // .test(
      //   "fileFormat",
      //   "Unsupported file format (only jpg/jpeg/png)",
      //   (value) => !value || (value && ["image/jpg", "image/jpeg", "image/png"].includes(value.type))
      // )
    });
  }

  handleRegister(formValue: { userName: string; email: string; password: string;  image: string}) {
    const { userName, email, password, image } = formValue;

    this.setState({
      message: "",
      successful: false
    });

    AuthService.register(
      userName,
      email,
      password,  
      image,   
    ).then(
      response => {
        this.setState({
          message: response.data.message,
          successful: true
        });
      },
      error => {
        const resMessage =
          (error.response &&
            error.response.data &&
            error.response.data.message) ||
          error.message ||
          error.toString();

        this.setState({
          successful: false,
          message: resMessage
        });
      }
    );
  }

  render() {
    const { successful, message } = this.state;

    const initialValues = {
      userName: "",
      email: "",
      password: "",
      image: ""
    };

    return (
      <div className="col-md-12">
        <div className="card card-container">
          <img
            src="//ssl.gstatic.com/accounts/ui/avatar_2x.png"
            alt="profile-img"
            className="profile-img-card"
          />

          <Formik
            initialValues={initialValues}
            validationSchema={this.validationSchema}
            onSubmit={this.handleRegister}
          >
            <Form> 
              {!successful && (
                <div>
                  <div className="form-group">
                    <label htmlFor="userName"> Username </label>
                    <Field name="userName" type="text" className="form-control" />
                    <ErrorMessage
                      name="userName"
                      component="div"
                      className="alert alert-danger"
                    />
                  </div>

                  <div className="form-group">
                    <label htmlFor="email"> Email </label>
                    <Field name="email" type="email" className="form-control" />
                    <ErrorMessage
                      name="email"
                      component="div"
                      className="alert alert-danger"
                    />
                  </div>

                  <div className="form-group">
                    <label htmlFor="password"> Password </label>
                    <Field
                      name="password"
                      type="password"
                      className="form-control"
                    />
                    <ErrorMessage
                      name="password"
                      component="div"
                      className="alert alert-danger"
                    />
                  </div>
 
                  {/* <div className="form-group">
                    <label htmlFor="image"> Image </label>
                    <Field
                      name="image"
                      type="file"
                      className="form-control"
                    />
                    <ErrorMessage
                      name="image"
                      component="div"
                      className="alert alert-danger"
                    />
                  </div> */}

                  <div className="form-group">
                    <button type="submit" className="btn btn-primary btn-block">Sign Up</button>
                  </div>
                </div>
              )}

              {message && (
                <div className="form-group">
                  <div
                    className={
                      successful ? "alert alert-success" : "alert alert-danger"
                    }
                    role="alert"
                  >
                    {message}
                  </div>
                </div>
              )}
            </Form>
          </Formik>
        </div>
      </div>
    );
  }
}
