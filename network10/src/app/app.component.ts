import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = "Network10";

  formMode: boolean = true; //true - create, false - edit
  messages: any[] = [];
  validateForm!: UntypedFormGroup;

  constructor(private http: HttpClient, private fb: UntypedFormBuilder) {
    this.getMessages();
  }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      id: [null, [Validators.required]],
      message: [null, [Validators.required]],
    });
  }

  getMessages() {
    this.http.get('/api/messages')
      .subscribe((resp: any) => this.messages = resp);
  }

  deleteMessage(id: number) {
    console.log("Deleting ", id);
    this.http.delete("/api/message/" + id).subscribe((resp: any) => this.getMessages());
  }

  clearForm() {
    this.formMode = true;
    this.validateForm.reset();
  }

  submitForm() {
    if (this.validateForm.valid) {
      console.log('submit', this.validateForm.value);

      const messageModel = {
        id: Number(this.validateForm.get('id')?.value),
        message: this.validateForm.get('message')?.value
      };

      if (this.formMode) {
        this.http.post("/api/message", messageModel).subscribe((resp: any) => this.getMessages());
      }
      else {
        this.http.put("/api/message/" + messageModel.id, messageModel).subscribe((resp: any) => this.getMessages());
      }

      this.validateForm.reset();
    } else {
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  editMessage(item: any) {
    this.formMode = false;

    this.validateForm.get('id')?.setValue(item.id);
    this.validateForm.get('message')?.setValue(item.message);
  }
}