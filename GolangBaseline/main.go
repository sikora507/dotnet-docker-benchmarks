package main

import (
	"bufio"
	"io"
	"log"
	"net/http"
	"os"
)

func main() {
	log.Print("Hello from GO.")

	resp, _ := http.Get("https://www.google.com")
	body, _ := io.ReadAll(resp.Body)

	log.Printf("Got %d bytes.", len(body))
	input := bufio.NewScanner(os.Stdin)
	input.Scan()
}
