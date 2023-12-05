//
//  BattleView.swift
//  Pokedex Test
//
//  Created by Martin on 14/11/23.
//

import SwiftUI

struct BattleView: View {
    var user: User
    var opp: User
    
    var body: some View {
        
        VStack {
            //Users and Pokeballs
            HStack {
                //User
                VStack {
                    //Info
                    HStack {
                        //IMG
                        Circle()
                            .frame(width: 27, height: 27)
                            .foregroundColor(/*@START_MENU_TOKEN@*/.blue/*@END_MENU_TOKEN@*/)
                        
                        //Username
                        Text("GrassyOG")
                            .font(.custom("GILROY-MEDIUM", size: 18))
                            .foregroundColor(.blue)
                    }
                    //balls
                    LazyHStack(content: {
                        ForEach(1...10, id: \.self) { count in
                            /*@START_MENU_TOKEN@*/Text("Placeholder \(count)")/*@END_MENU_TOKEN@*/
                        }
                    })
                }
                //Opponent
                Circle()
                    .frame(width: 27, height: 27)
                    .foregroundColor(.red)
            }
            //Active Pokemon
            HStack {
                //User
                ActivePokemon(poke: user.pokemonCollection[0] ?? Pokemon.MOCK_POKEMON[2])
                
                ActivePokemon(poke: opp.pokemonCollection[2] ?? Pokemon.MOCK_POKEMON[4])
                //Opponent
                
            }
            // Change Pokemon
            HStack {
                
            }
            
            //Moves
        }
        Text(user.username)
        
        ForEach(user.pokemonCollection ?? Pokemon.MOCK_POKEMON) { poke in
            Text(poke.name)
            
        }
    }
}

#Preview {
    BattleView(user: User.MOCK_USERS[2], opp: User.MOCK_USERS[3])
}
