#include <stm32f4xx_usart.h> // under Libraries/STM32F4xx_StdPeriph_Driver/inc and src
#include "stm32f4xx.h"
#include "stm32f4xx_gpio.h"
#include "stm32f4xx_rcc.h"
#include "stm32f4xx_tim.h"
#include "misc.h"
#include "stm32f4xx_syscfg.h"
#include "stm32f4xx_exti.h"

#define MAX_STRLEN 20 // this is the maximum string length of our string in characters
volatile char received_string[MAX_STRLEN+1]; // this will hold the recieved string

void Delay(__IO uint32_t nCount) {
  while(nCount--) {
  }
}

void ClearString(){
	int a = 0;
	while(a < MAX_STRLEN){
		received_string[a] = '\0';
		a++;
	}
}
/* This funcion initializes the USART1 peripheral
 *
 * Arguments: baudrate --> the baudrate at which the USART is
 * 						   supposed to operate
 */

void initLEDs() {
        GPIO_InitTypeDef GPIO_InitStructure;
        RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);

        GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12 | GPIO_Pin_14 | GPIO_Pin_15;
        GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
        GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
        GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
        GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;

        GPIO_Init(GPIOD, &GPIO_InitStructure);

        GPIO_InitTypeDef GPIO_InitStructure2;

		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);

		GPIO_InitStructure2.GPIO_Pin =  GPIO_Pin_13;
		GPIO_InitStructure2.GPIO_Mode = GPIO_Mode_OUT;
		GPIO_InitStructure2.GPIO_OType = GPIO_OType_PP;
		GPIO_InitStructure2.GPIO_Speed = GPIO_Speed_100MHz;
		GPIO_InitStructure2.GPIO_PuPd = GPIO_PuPd_NOPULL;

		GPIO_Init(GPIOD, &GPIO_InitStructure2);
		//GPIO_ResetBits(GPIOD, GPIO_Pin_12|GPIO_Pin_13|GPIO_Pin_14|GPIO_Pin_15);
		//GPIO_SetBits(GPIOD, GPIO_Pin_12|GPIO_Pin_13|GPIO_Pin_14|GPIO_Pin_15);
		//GPIO_SetBits(GPIOD, GPIO_Pin_12);
		//GPIO_ResetBits(GPIOD, GPIO_Pin_12);
		//Delay(0x1FFFF3);
}

void initButton() {
        GPIO_InitTypeDef GPIO_InitStructure;
        RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);

        GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
        GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
        GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0;

        GPIO_Init(GPIOA, &GPIO_InitStructure) ;
}


char red[] = "red-on";
char green[] = "green-on";
char blue[] = "blue-on";
char yellow[] = "yellow-on";
char red2[] = "red-off";
char green2[] = "green-off";
char blue2[] = "blue-off";
char yellow2[] = "yellow-off";
char alloff[] = "all-off";
char allon[] = "all-on";

int Interpreter(char *command){
	if(strcmp(command, red) == 0) return 1;
	else if(strcmp(command, green) == 0) return 2;
	else if(strcmp(command, blue) == 0) return 3;
	else if(strcmp(command, yellow) == 0) return 4;
	else if(strcmp(command, red2) == 0) return 5;
	else if(strcmp(command, green2) == 0) return 6;
	else if(strcmp(command, blue2) == 0) return 7;
	else if(strcmp(command, yellow2) == 0) return 8;
	else if(strcmp(command, alloff) == 0) return 9;
	else if(strcmp(command, allon) == 0) return 10;
	else return 0;
}

void ControlComand(char* command){
	switch(Interpreter(command)){
	case 1: {
			GPIO_SetBits(GPIOD, GPIO_Pin_14);
			USART_puts(USART1, "Czerwona dioda zapalona!&");
			break;
		}
	case 2: {
				GPIO_SetBits(GPIOD, GPIO_Pin_12);
				USART_puts(USART1, "Zielona dioda zapalona!&");
				break;
			}
	case 3: {
				GPIO_SetBits(GPIOD, GPIO_Pin_15);
				USART_puts(USART1, "Niebieska dioda zapalona!&");
				break;
			}
	case 4: {
				GPIO_SetBits(GPIOD, GPIO_Pin_13);
				USART_puts(USART1, "Zolta dioda zapalona!&");
				break;
			}
	case 5: {
				GPIO_ResetBits(GPIOD, GPIO_Pin_14);
				USART_puts(USART1, "Czerwona dioda OFF!&");
				break;
			}
	case 6: {
				GPIO_ResetBits(GPIOD, GPIO_Pin_12);
				USART_puts(USART1, "Zielona dioda OFF!&");
				break;
			}
	case 7: {
				GPIO_ResetBits(GPIOD, GPIO_Pin_15);
				USART_puts(USART1, "Niebieska dioda OFF!&");
				break;
			}
	case 8: {
				GPIO_ResetBits(GPIOD, GPIO_Pin_13);
				USART_puts(USART1, "Zolta dioda OFF!&");
				break;
			}
	case 9: {
				GPIO_ResetBits(GPIOD, GPIO_Pin_12);
				GPIO_ResetBits(GPIOD, GPIO_Pin_13);
				GPIO_ResetBits(GPIOD, GPIO_Pin_14);
				GPIO_ResetBits(GPIOD, GPIO_Pin_15);
				USART_puts(USART1, "Wszystkie diody OFF!&");
				break;
			}
	case 10: {
				GPIO_SetBits(GPIOD, GPIO_Pin_12);
				GPIO_SetBits(GPIOD, GPIO_Pin_13);
				GPIO_SetBits(GPIOD, GPIO_Pin_14);
				GPIO_SetBits(GPIOD, GPIO_Pin_15);
				USART_puts(USART1, "Wszystkie diody ON!&");
				break;
			}
	default: {
			USART_puts(USART1, "Error!&");
			break;
		}
	}

}

void init_USART1(uint32_t baudrate){

	/* This is a concept that has to do with the libraries provided by ST
	 * to make development easier the have made up something similar to
	 * classes, called TypeDefs, which actually just define the common
	 * parameters that every peripheral needs to work correctly
	 *
	 * They make our life easier because we don't have to mess around with
	 * the low level stuff of setting bits in the correct registers
	 */
	GPIO_InitTypeDef GPIO_InitStruct; // this is for the GPIO pins used as TX and RX
	USART_InitTypeDef USART_InitStruct; // this is for the USART1 initilization
	NVIC_InitTypeDef NVIC_InitStructure; // this is used to configure the NVIC (nested vector interrupt controller)

	/* enable APB2 peripheral clock for USART1
	 * note that only USART1 and USART6 are connected to APB2
	 * the other USARTs are connected to APB1
	 */
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART1, ENABLE);

	/* enable the peripheral clock for the pins used by
	 * USART1, PB6 for TX and PB7 for RX
	 */
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);

	/* This sequence sets up the TX and RX pins
	 * so they work correctly with the USART1 peripheral
	 */
	GPIO_InitStruct.GPIO_Pin = GPIO_Pin_6 | GPIO_Pin_7; // Pins 6 (TX) and 7 (RX) are used
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_AF; 			// the pins are configured as alternate function so the USART peripheral has access to them
	GPIO_InitStruct.GPIO_Speed = GPIO_Speed_50MHz;		// this defines the IO speed and has nothing to do with the baudrate!
	GPIO_InitStruct.GPIO_OType = GPIO_OType_PP;			// this defines the output type as push pull mode (as opposed to open drain)
	GPIO_InitStruct.GPIO_PuPd = GPIO_PuPd_UP;			// this activates the pullup resistors on the IO pins
	GPIO_Init(GPIOB, &GPIO_InitStruct);					// now all the values are passed to the GPIO_Init() function which sets the GPIO registers

	/* The RX and TX pins are now connected to their AF
	 * so that the USART1 can take over control of the
	 * pins
	 */
	GPIO_PinAFConfig(GPIOB, GPIO_PinSource6, GPIO_AF_USART1); //
	GPIO_PinAFConfig(GPIOB, GPIO_PinSource7, GPIO_AF_USART1);

	/* Now the USART_InitStruct is used to define the
	 * properties of USART1
	 */
	USART_InitStruct.USART_BaudRate = baudrate;				// the baudrate is set to the value we passed into this init function
	USART_InitStruct.USART_WordLength = USART_WordLength_8b;// we want the data frame size to be 8 bits (standard)
	USART_InitStruct.USART_StopBits = USART_StopBits_1;		// we want 1 stop bit (standard)
	USART_InitStruct.USART_Parity = USART_Parity_No;		// we don't want a parity bit (standard)
	USART_InitStruct.USART_HardwareFlowControl = USART_HardwareFlowControl_None; // we don't want flow control (standard)
	USART_InitStruct.USART_Mode = USART_Mode_Tx | USART_Mode_Rx; // we want to enable the transmitter and the receiver
	USART_Init(USART1, &USART_InitStruct);					// again all the properties are passed to the USART_Init function which takes care of all the bit setting


	/* Here the USART1 receive interrupt is enabled
	 * and the interrupt controller is configured
	 * to jump to the USART1_IRQHandler() function
	 * if the USART1 receive interrupt occurs
	 */
	USART_ITConfig(USART1, USART_IT_RXNE, ENABLE); // enable the USART1 receive interrupt

	NVIC_InitStructure.NVIC_IRQChannel = USART1_IRQn;		 // we want to configure the USART1 interrupts
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;// this sets the priority group of the USART1 interrupts
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;		 // this sets the subpriority inside the group
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;			 // the USART1 interrupts are globally enabled
	NVIC_Init(&NVIC_InitStructure);							 // the properties are passed to the NVIC_Init function which takes care of the low level stuff

	// finally this enables the complete USART1 peripheral
	USART_Cmd(USART1, ENABLE);
}

/* This function is used to transmit a string of characters via
 * the USART specified in USARTx.
 *
 * It takes two arguments: USARTx --> can be any of the USARTs e.g. USART1, USART2 etc.
 * 						   (volatile) char *s is the string you want to send
 *
 * Note: The string has to be passed to the function as a pointer because
 * 		 the compiler doesn't know the 'string' data type. In standard
 * 		 C a string is just an array of characters
 *
 * Note 2: At the moment it takes a volatile char because the received_string variable
 * 		   declared as volatile char --> otherwise the compiler will spit out warnings
 * */
void USART_puts(USART_TypeDef* USARTx, volatile char *s){

	while(*s){
		// wait until data register is empty
		while( !(USARTx->SR & 0x00000040) );
		USART_SendData(USARTx, *s);
		*s++;
	}
}

int main(void) {
	initButton();
	initLEDs();
	init_USART1(9600); // initialize USART1 @ 9600 baud

	//USART_puts(USART1, "Init complete! Hello World!&"); // just send a message to indicate that it works


	while (1){
		if(GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_0)){
			char buff[100] = "Stan diod:\n";

			strcat(buff, "Zielona-");
			if(GPIO_ReadInputDataBit(GPIOD, GPIO_Pin_12)) strcat(buff, "ON\n");
			else strcat(buff, "OFF\n");

			strcat(buff, "Zolta-");
			if(GPIO_ReadInputDataBit(GPIOD, GPIO_Pin_13)) strcat(buff, "ON\n");
			else strcat(buff, "OFF\n");

			strcat(buff, "Czerwona-");
			if(GPIO_ReadInputDataBit(GPIOD, GPIO_Pin_14)) strcat(buff, "ON\n");
			else strcat(buff, "OFF\n");

			strcat(buff, "Niebieska-");
			if(GPIO_ReadInputDataBit(GPIOD, GPIO_Pin_15)) strcat(buff, "ON&");
			else strcat(buff, "OFF&");

			USART_puts(USART1, buff);

			Delay(0x1FFFF3);
		}
	/*
	 * You can do whatever you want in here
	 */
	}
}

static uint8_t cnt = 0;
// this is the interrupt request handler (IRQ) for ALL USART1 interrupts
void USART1_IRQHandler(void){

	// check if the USART1 receive interrupt flag was set
	if( USART_GetITStatus(USART1, USART_IT_RXNE) ){

		 // this counter is used to determine the string length
		char t = USART1->DR; // the character from the USART1 data register is saved in t

		/* check if the received character is not the LF character (used to determine end of string)
		 * or the if the maximum string length has been been reached
		 */
		if( (t != '&') && (t != '\n') ){
			received_string[cnt] = t;
			cnt++;
		}
		else if( t == '\n'){

		}
		else {
			received_string[cnt] = '\0';
			ControlComand(received_string);
			received_string[cnt] = t;
			cnt = 0;
			ClearString();
		}
	}
}

