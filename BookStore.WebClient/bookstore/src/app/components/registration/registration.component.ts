import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from "src/app/service/authentication.service"

@Component({ templateUrl: 'registration.component.html' })
export class RegistrationComponent implements OnInit {
    registerForm: FormGroup;
    loading = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private userService: AuthenticationService) { }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({

            UserName: ['', Validators.compose([Validators.required])],
            Password: ['', Validators.compose([Validators.required, Validators.minLength(6)])],
            ConfirmPassword: ['', Validators.compose([Validators.required, Validators.minLength(6)])]

        });

    }

    // convenience getter for easy access to form fields
    get f() {
        if (this.registerForm.get('password') != this.registerForm.get("confirmpassword")) {
            return this.registerForm.controls['confirmpassword'].valid;
        }
        return this.registerForm.controls;
    }

    onSubmit() {
        this.submitted = true;
        // stop here if form is invalid
        if (this.registerForm.invalid) {
            return;
        }

        this.loading = true;
        this.userService.register(this.registerForm.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate(['']);
                },

                error => {
                    this.loading = false;
                });
    }
}
