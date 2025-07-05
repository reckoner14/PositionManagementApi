import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { PositionService } from '../position.service';

@Component({
  standalone: true,
  selector: 'app-position-management',
  templateUrl: './position-management.html',
  styleUrls: ['./position-management.scss'],
  imports: [
    CommonModule,         // Enables *ngIf, *ngFor
    ReactiveFormsModule   // Enables formGroup, formControlName
  ]
})
export class PositionManagementComponent implements OnInit {
  transactionForm!: FormGroup;
  positions: any[] = [];
  constructor(private fb: FormBuilder, private positionService: PositionService) {}

  ngOnInit(): void {
    this.transactionForm = this.fb.group({
      tradeId: ['', Validators.required],
      version: ['', Validators.required],
      securityCode: ['', Validators.required],
      quantity: ['', Validators.required],
      action: ['INSERT', Validators.required],
      buySell: ['Buy', Validators.required]
    });

    this.getPositions();
  }

  submitTransaction(): void {
    if (this.transactionForm.valid) {
      const transaction = {
        transactionId: Date.now(),
        ...this.transactionForm.value,
        tradeId: parseInt(this.transactionForm.value.tradeId),
        version: parseInt(this.transactionForm.value.version),
        quantity: parseInt(this.transactionForm.value.quantity)
      };

      this.positionService.submitTransaction(transaction).subscribe({
        next: () => this.getPositions(),
        error: (err) => console.error('Error posting transaction', err)
      });
    }
  }

  getPositions(): void {
    this.positionService.getPositions().subscribe({
      next: (data) => (this.positions = data),
      error: (err) => console.error('Error fetching positions', err)
    });
  }
}
