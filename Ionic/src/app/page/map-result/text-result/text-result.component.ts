import { Component, OnInit, Input } from '@angular/core';
import { Result } from 'src/app/shared/models/result';
import { Appointment } from 'src/app/shared/models/appointment';
import { AppointmentService } from 'src/app/shared/services/appointment.service';
import { Router } from '@angular/router';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-text-result',
  templateUrl: './text-result.component.html',
  styleUrls: ['./text-result.component.scss'],
})
export class TextResultComponent implements OnInit {
@Input() reult:Result
  @Input() notRealAppointments: Appointment[]
  constructor(private appointmentService:AppointmentService,
    private router:Router,
  private  modalCtrl: ModalController) { }

  ngOnInit() {}

  dismiss() {
    
    this.modalCtrl.dismiss({
      'dismissed': true
    });
  }
getTimeString(date)
{
  return new Date(date).toLocaleTimeString();
}

  deleteAppointment(id) {
    this.appointmentService.deleteAppointment(id).subscribe(res => {
      this.router.navigate(['map-result', JSON.stringify(res)])
    })
  }
}